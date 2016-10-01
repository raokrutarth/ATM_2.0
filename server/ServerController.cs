using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtmServer
{
    class ServerController
    {
        static void Main(string[] args)
        {
            int i = 9;
            int loop = 15;
            while(loop > 0)
            {
                Console.WriteLine("Testing...");
                Thread nt = new Thread(() => printFib(i++) );
                nt.Start();
                String line = Console.ReadLine();     
                           
            }
        }

        static void printFib(int n)
        {
            Console.WriteLine("fib(" + n + ") : " + fib(n));
        }       

        static long fib(int n)
        {
            if (n <= 1)
                return 1;
            else
                return fib(n - 1) + fib(n - 2);
        }
    }
}
