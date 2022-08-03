using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uncomment 1 of them for see the behaviour of the single
            //AllProcess();
            //AllProcess2();

            Console.ReadKey();
        }

        static void AllProcess()
        {
            Process1_2();
            Calculation3(); 
        }

        static async void AllProcess2()
        {
            await awaitProcess();
        }

        static async Task awaitProcess()
        {
            await Process1_2();

            Calculation3();
            
        }

        static async Task Process1_2()
        {
            //remember await inside the async
            var task = await Task.Run(() =>
            {
                return Calculation1();
            });

            //task is already an int from the return, don't need .Result
            Calculation2(task);
            //work as a Callback
        }

        static int Calculation1()
        {
            Thread.Sleep(1000); //Make the process sleep 1s (is counted on ms)
            Console.WriteLine("Calculation1 - Done");
            return 1;
        }

        static int Calculation2(int i)
        {
            Thread.Sleep(2000); //Make the process sleep 1s (is counted on ms)
            Console.WriteLine("Callback - Calculation2 - Done - Value: " + +(i+2));
            return 2+i;
        }

        static int Calculation3()
        {
            Thread.Sleep(100); //Make the process sleep 1s (is counted on ms)
            Console.WriteLine("Calculation3 - Done");
            return 3;
        }

    }
}
