using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace Lab_21
{
    class Program
    {
        static int[,] garden;
        static int n;
        static int m;
        static void Main(string[] args)
        {
            n = 4;
            m = 4;
            garden = new int[n, m];
            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread myThread = new Thread(threadStart);
            myThread.Start();
            ThreadStart threadStart1 = new ThreadStart(Gardener2);
            Thread myThread1 = new Thread(threadStart1);
            myThread1.Start();
            myThread.Join();
            myThread1.Join();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        public static void Gardener1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (garden[i, j] == 0)
                        garden[i, j] = 1;
                    Thread.Sleep(100);
                }
            }
        }
        public static void Gardener2()
        {
            for (int i = m-1; i>0; i--)
            {
                for (int j = n-1; j>0; j--)
                {
                    if (garden[j, i] == 0)
                        garden[j, i] = 2;
                    Thread.Sleep(100);
                }
            }
        }
    }
    
}
