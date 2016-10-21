using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateDemo4
{
    class Program
    {
        private static string Name ="NAME";
        static void Main(string[] args)
        {

            //Action<string> action = delegate (string name) { Console.WriteLine(name); };

            //Action<string> action =  (string name) => { Console.WriteLine(name); };

            //Action<string> action = name => Console.WriteLine(name);
            //action(" Test");
            Action action = () => Console.WriteLine("Test");
            action += () => Console.WriteLine(Name);
            action();
            Console.ReadKey();
        }
    }
}
