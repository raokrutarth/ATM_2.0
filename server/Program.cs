using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while(true)
            {
                Console.WriteLine("Testing...");
                //String line = Console.ReadLine();
                Console.WriteLine("fib(" + i +") : "  + fib(i++));
            }
        }

        static int fib(int n)
        {
            if (n <= 1)
                return 1;
            else
                return fib(n - 1) + fib(n - 2);
        }
    }
}
