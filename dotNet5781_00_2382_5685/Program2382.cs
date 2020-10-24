using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_00_2382_5685
{
   partial class Program
    {
        static void Main(string[] args)

        {
            
            Welcome2382();
            Welcome5685();
            Console.ReadKey();
        }

        private static void Welcome2382()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
        static partial void Welcome5685();
          
    }
}
