using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylorSeries.Logic;

namespace TylorSeries.App
{
    class Program
    {
        static TylorCalculator calculator = new TylorCalculator();

        static void Main(string[] args)
        {
            Stopwatch watch;

            // quick n dirty...
            watch = new Stopwatch();
            watch.Start();
            var result_5 = calculator.getTylorResultReverse(1, 5);
            watch.Stop();
            Console.WriteLine(result_5);
            Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");

            watch = new Stopwatch();
            watch.Start();
            var result_10 = calculator.getTylorResultReverse(1, 10);
            watch.Stop();
            Console.WriteLine(result_10);
            Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");

            watch = new Stopwatch();
            watch.Start();
            var result_100 = calculator.getTylorResultReverse(1, 100);
            watch.Stop();
            Console.WriteLine(result_100);
            Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");

            watch = new Stopwatch();
            watch.Start();
            var result_1000 = calculator.getTylorResultReverse(1, 1000);
            watch.Stop();
            Console.WriteLine(result_1000);
            Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");

            watch = new Stopwatch();
            watch.Start();
            var result_10000 = calculator.getTylorResultReverse(1, 10000);
            watch.Stop();
            Console.WriteLine(result_10000);
            Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");

            watch = new Stopwatch();
            watch.Start();
            var result_100000 = calculator.getTylorResultReverse(1, 100000);
            watch.Stop();
            Console.WriteLine(result_100000);
            Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");

            watch = new Stopwatch();
            watch.Start();
            var result_1000000 = calculator.getTylorResultReverse(1, 1000000);
            watch.Stop();
            Console.WriteLine(result_1000000);
            Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");

            watch = new Stopwatch();
            watch.Start();
            var result_10000000 = calculator.getTylorResultReverse(1, 10000000);
            watch.Stop();
            Console.WriteLine(result_10000000);
            Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");

            //watch = new Stopwatch();
            //watch.Start();
            //var result_100000000 = calculator.getTylorResultReverse(1, 100000000);
            //watch.Stop();
            //Console.WriteLine(result_100000000);
            //Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");


            /*
             * Divide and Conquer - Beispiel wie man es optimieren könnte...
             * Quick&Dirty => Iterationen herunterbrechen und via loop die tasks erstellen. Flexibler und schöner...
            */

            var task = new List<Task>();
            var results = new System.Collections.Concurrent.BlockingCollection<double>();

            watch = new Stopwatch();
            watch.Start();

            task.Add(Task.Run(() => {
                var calc = new TylorCalculator();
                results.Add(calc.getTylorResultReverseDivideAndConquer(1, 0, 10000000));
            }));

            task.Add(Task.Run(() => {
                var calc = new TylorCalculator();
                results.Add(calc.getTylorResultReverseDivideAndConquer(1, 10000000, 20000000));
            }));

            task.Add(Task.Run(() => {
                var calc = new TylorCalculator();
                results.Add(calc.getTylorResultReverseDivideAndConquer(1, 20000000, 30000000));
            }));

            task.Add(Task.Run(() => {
                var calc = new TylorCalculator();
                results.Add(calc.getTylorResultReverseDivideAndConquer(1, 30000000, 40000000));
            }));

            task.Add(Task.Run(() => {
                var calc = new TylorCalculator();
                results.Add(calc.getTylorResultReverseDivideAndConquer(1, 40000000, 50000000));
            }));

            task.Add(Task.Run(() => {
                var calc = new TylorCalculator();
                results.Add(calc.getTylorResultReverseDivideAndConquer(1, 50000000, 60000000));
            }));

            task.Add(Task.Run(() => {
                var calc = new TylorCalculator();
                results.Add(calc.getTylorResultReverseDivideAndConquer(1, 60000000, 70000000));
            }));

            task.Add(Task.Run(() => {
                var calc = new TylorCalculator();
                results.Add(calc.getTylorResultReverseDivideAndConquer(1, 70000000, 80000000));
            }));

            task.Add(Task.Run(() => {
                var calc = new TylorCalculator();
                results.Add(calc.getTylorResultReverseDivideAndConquer(1, 80000000, 90000000));
            }));

            task.Add(Task.Run(() => {
                var calc = new TylorCalculator();
                results.Add(calc.getTylorResultReverseDivideAndConquer(1, 90000000, 100000000));
            }));

            Task.WhenAll(task.ToArray()).Wait();
            
            watch.Stop();

            Console.WriteLine(results.Sum());
            Console.WriteLine("Measured time: " + watch.Elapsed.TotalMilliseconds + " ms.");

            Console.WriteLine("Done: 5...100'000'000");
            Console.ReadLine();
        }
    }
}
