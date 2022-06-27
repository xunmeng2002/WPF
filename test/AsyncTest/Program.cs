using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        public static void TraceThreadAndTask(string info)
        {
            string taskInfo = Task.CurrentId == null ? "no task" : "task" + Task.CurrentId;
            Console.WriteLine($"{info} in thread {Thread.CurrentThread.ManagedThreadId}" + $" and {taskInfo}");
        }
        static string Greeting(string name)
        {
            TraceThreadAndTask($"running {nameof(Greeting)}");
            Task.Delay(3000).Wait();
            return $"Hello, {name}";
        }
        static Task<string> GreetingAsync(string name) =>
            Task.Run<string>(()=>
            {
                TraceThreadAndTask($"running {nameof(GreetingAsync)}");
                return Greeting(name);
            });
        private async static void CallerWithAsync()
        {
            TraceThreadAndTask($"started {nameof(CallerWithAsync)}");
            string result = await GreetingAsync("Stephanie");
            Console.WriteLine(result);
            TraceThreadAndTask($"ended {nameof(CallerWithAsync)}");
        }
        private async static void CallerWithAsync2()
        {
            TraceThreadAndTask($"started {nameof(CallerWithAsync2)}");
            Console.WriteLine(await GreetingAsync("Stephanie"));
            TraceThreadAndTask($"ended {nameof(CallerWithAsync2)}");
        }

        private static void CallerWithAwaiter()
        {
            TraceThreadAndTask($"starting {nameof(CallerWithAwaiter)}");
            TaskAwaiter<string> awaiter = GreetingAsync("Matthias").GetAwaiter();
            awaiter.OnCompleted(OnCompleteAwaiter);

            void OnCompleteAwaiter()
            {
                Console.WriteLine(awaiter.GetResult());
                TraceThreadAndTask($"ended {nameof(CallerWithAwaiter)}");
            }
        }
        private static void CallerWithContinuationTask()
        {
            TraceThreadAndTask($"starting {nameof(CallerWithContinuationTask)}");

            Task<string> t1 = GreetingAsync("Stephanie");
            //t1.ConfigureAwait(false);
            t1.ContinueWith(t =>
            {
                string result = t.Result;
                Console.WriteLine(result);

                TraceThreadAndTask($"ended {nameof(CallerWithContinuationTask)}");
            });
        }

        static void Main(string[] args)
        {
            CallerWithAsync();
            CallerWithAsync2();
            CallerWithAwaiter();
            CallerWithContinuationTask();

            Console.Read();
        }
    }
}
