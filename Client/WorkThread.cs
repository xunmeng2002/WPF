using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using Google.Protobuf;
using Tutorial;


namespace Client
{
    class WorkThread
    {
        private Thread thread;
        private long shouldRun;
        private TcpClient tcpClient;
        private String server;
        private Int32 port;
        private MainWindow mainWindow;
        public WorkThread(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            thread = new Thread(new ParameterizedThreadStart(ThreadStart));
            shouldRun = 0;
            tcpClient = new TcpClient();
        }
        public void Init(String server, Int32 port)
        {
            this.server = server;
            this.port = port;
        }
        public void Start()
        {
            Interlocked.Exchange(ref shouldRun, 1);
            thread.Start(this);
        }
        public void Stop()
        {
            Interlocked.Exchange(ref shouldRun, 0);
        }
        public void Join()
        {
            if (thread.IsAlive)
            {
                thread.Join();
            }
        }
        public static void PrintMessage(IMessage message)
        {
            var descriptor = message.Descriptor;
            foreach (var field in descriptor.Fields.InDeclarationOrder())
            {
                Console.WriteLine(
                    "Field {0} ({1}): {2}",
                    field.FieldNumber,
                    field.Name,
                    field.Accessor.GetValue(message));
            }
        }
        public static void ThreadStart(Object workThread)
        {
            WorkThread workThread1 = (WorkThread)workThread;
            workThread1.tcpClient.Connect(workThread1.server, workThread1.port);
            int series = 1;

            while (Interlocked.Read(ref workThread1.shouldRun) == 1)
            {
                if(series <= 2)
                {
                    Person person = new Person
                    {
                        Id = series,
                        Name = "John Doe " + series.ToString(),
                        Email = "jdoe@example.com",
                        Phones = { new PhoneNumber { Number = "18019749894", Type = PhoneType.Home }, new PhoneNumber { Number = "18511899894", Type = PhoneType.Work } }
                    };

                    var stream = workThread1.tcpClient.GetStream();
                    person.WriteTo(stream);
                    //stream.Write(person.ToByteArray());

                    //FileStream file = new FileStream("clientSend.txt", FileMode.Create);
                    //file.Write(person.ToByteArray());
                    //file.Close();

                    //String message = "Message From CSharp. Series:" + series.ToString();
                    //Byte[] sendBuff = System.Text.Encoding.ASCII.GetBytes(message);
                    //stream.Write(sendBuff, 0, sendBuff.Length);
                    //string sendData = System.Text.Encoding.ASCII.GetString(sendBuff, 0, sendBuff.Length);
                    //Console.WriteLine("Send: {0}", sendData);
                    //workThread1.mainWindow.UpdateSendMessage(sendData);

                    //Byte[] recvBuff = new Byte[1024];
                    //Int32 len = stream.Read(recvBuff, 0, recvBuff.Length);
                    //string recvData = System.Text.Encoding.ASCII.GetString(recvBuff, 0, len);
                    //Console.WriteLine("Received: {0}", recvData);
                    //workThread1.mainWindow.UpdateRecvMessage(recvData);

                    //FileStream file1 = new FileStream("clientRecv.txt", FileMode.Append);
                    //file1.Write(recvBuff);
                    //file1.Close();

                    Byte[] recvBuff = new Byte[1024];
                    Int32 len = stream.Read(recvBuff, 0, recvBuff.Length);

                    Person person2 = new Person();
                    person2 = Person.Parser.ParseFrom(recvBuff, 0, len);
                    PrintMessage(person2);
                }

                series++;
                Thread.Sleep(1000);
            }
            workThread1.tcpClient.Close();
        }
    }
}
