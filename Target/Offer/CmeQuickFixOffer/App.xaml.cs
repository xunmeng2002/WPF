using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using OfferCommonLibrary;
using OfferCommonLibrary.Its;
using OfferCommonLibrary.Mdb;
using QuickFix;
using QuickFix.Transport;

namespace CmeQuickFixOffer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public App()
        {
            using (FileStream fs = new FileStream(ConfigFileName, FileMode.Open))
            {
                var config = JsonSerializer.Deserialize<Config>(fs);
                if (config == null)
                {
                    throw new Exception("Program Start Failed For Config: " + ConfigFileName);
                }
                AppConfig = config;
            }

            AppService.AddSingleton(AppConfig);
            AppService.AddLogging(loggingBuilder => { loggingBuilder.AddNLog(Configuration); });
            MdbViewModelInit.Init(AppService);
            AppService.AddSingleton<MdbEngine>();
            AppService.AddSingleton<ItsEngine>();
            AppService.AddSingleton<MainWindow>();

            AppService.AddSingleton(settings);
            AppService.AddSingleton(storeFactory);
            AppService.AddSingleton(logFactory);
            AppService.AddSingleton<QuickFixApplication>();
            AppService.AddSingleton<SocketInitiator>();


            AppServiceProvider = AppService.BuildServiceProvider();

            MdbEngine? mdbEngine = AppServiceProvider.GetService<MdbEngine>();
            ItsEngine? itsEngine = AppServiceProvider.GetService<ItsEngine>();
            if(mdbEngine != null || itsEngine != null)
            {
                throw new Exception($"Create MdbEngine:{mdbEngine} Or ItsEngine:{itsEngine}  Failed.");
            }
            mdbEngine.Init(itsEngine);
            itsEngine.Init(mdbEngine);
            itsEngine.Start();


            application = AppServiceProvider.GetService<QuickFixApplication>();
            if (application == null)
            {
                throw new Exception("Create QuickFix Failed.");
            }
            initiator = new SocketInitiator(application, storeFactory, settings, logFactory);
            application.Init(AppConfig, initiator);
        }
        public IConfiguration Configuration { get; set; } = new ConfigurationBuilder().Build();
        public IServiceCollection AppService { get; set; } = new ServiceCollection();
        public IServiceProvider AppServiceProvider { get; set; }
        private static readonly string ConfigFileName = "QuickFixTest.json";
        public Config AppConfig { get; set; }
        
        private static readonly string QuickFixConfigFileName = "QuickFix.cfg";
        private static SessionSettings settings = new SessionSettings(QuickFixConfigFileName);
        private static IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
        private static ILogFactory logFactory = new FileLogFactory(settings);
        private QuickFixApplication? application;
        private IInitiator initiator;


        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Parallel.Invoke(initiator.Start);

            var mainWindow = AppServiceProvider.GetService<MainWindow>();
            if (mainWindow != null)
            {
                mainWindow.Show();
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if(initiator != null)
            {
                initiator.Stop();
            }
        }
    }
}
