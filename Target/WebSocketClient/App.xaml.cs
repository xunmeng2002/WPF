using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WebSocketClient.Mdb;

namespace WebSocketClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var config = Config.Load(ConfigFileName);
            if (config == null)
            {
                throw new Exception("Program Start Failed For Config: " + ConfigFileName);
            }
            AppConfig = config;

            AppService.AddSingleton(AppConfig);
            AppService.AddLogging(loggingBuilder => { loggingBuilder.AddNLog(Configuration); });
            AppService.AddSingleton<MdbEngine>();
            AppService.AddSingleton<MainWindow>();

            AppServiceProvider = AppService.BuildServiceProvider();
        }
        private readonly string ConfigFileName = "WebSocketClient.json";
        public Config AppConfig { get; set; }
        public IConfiguration Configuration { get; set; } = new ConfigurationBuilder().Build();
        public IServiceCollection AppService { get; set; } = new ServiceCollection();
        public IServiceProvider AppServiceProvider { get; set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = AppServiceProvider.GetService<MainWindow>();
            if (mainWindow != null)
            {
                mainWindow.Show();
            }
        }
    }
}
