using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //push pop method 
            // Create and initialize a stack
            Stack stk = new Stack();
            stk.Push("Welcome");
            stk.Push("Ajay kumar ");
            stk.Push(20.5f);//f mean floating no. 
            stk.Push(10);
            stk.Push(null);
            stk.Push(100);
            Console.WriteLine("Number of Elements in Stack: {0}", stk.Count);
            Console.WriteLine("***Stack Elements***");
            // Access Stack Elements
            foreach (var item in stk)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
