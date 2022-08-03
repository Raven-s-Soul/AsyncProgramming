using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AllProcess();

            // For who has the auto close active after the ending of debug
            // And Work as Process Killer for the Multy Threading in this console app
            Console.ReadKey(); 
        }

        static void AllProcess()
        {
            
            //Task.Run make a thread work on the task
            var task1 = Task.Run(() =>
            {
                return Calculation1();
            });

            var task2 = Task.Run(() =>
            {
                return Calculation2();
            });
   
            //When the task is done, this will be printed on the console!
            //And will stop the Multy Threading from full async
            //Console.WriteLine(task1.Result);
            //Console.WriteLine(task2.Result);

            //This is going to wait till the Task are done
            //Task.WaitAll(task1 , task2);

            //The Awaiter can do things like tell you the state "IsCompleted"[bool] and "OnCompleted" call [callback function]
            //var awaiter1 = task1.GetAwaiter();
            //var awaiter2 = task2.GetAwaiter();

            var task3 = Task.Run(() =>
            {
                return Calculation3();
            });

            var awaiter3 = task3.GetAwaiter();

            //callback function at the end of task3
            awaiter3.OnCompleted(() => 
            {
                callbackCalculation4(awaiter3.GetResult());
            });

        }

        static int Calculation1()
        {
            Thread.Sleep(1000); //Make the process sleep 1s (is counted on ms)
            Console.WriteLine("Calculation1 - Done");
            return 1;
        }

        static int Calculation2()
        {
            Thread.Sleep(2000); //Make the process sleep 1s (is counted on ms)
            Console.WriteLine("Calculation2 - Done");
            return 2;
        }

        static int Calculation3()
        {
            Thread.Sleep(100); //Make the process sleep 1s (is counted on ms)
            Console.WriteLine("Calculation3 - Done");
            return 3;
        }

        static void callbackCalculation4(int callback)
        {
            Thread.Sleep(100); //Make the process sleep 1s (is counted on ms)
            Console.WriteLine("Callback - Calculation3 - Value: " + callback);
        }
    }
}
