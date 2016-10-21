using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateDemo1
{
    internal delegate int GetResult(int max,int min);
    class Program
    {
        static void Main(string[] args)
        {
            GetResult getResult = null;
            getResult += GetSum;
            getResult += GetMedium;
            getResult += GetProduct;
            Console.WriteLine(getResult(1,2));
            Console.ReadKey();
        }

        public static int GetSum(int max,int min)
        {
            return max + min;
        }


        public static int GetMedium(int max,int min)
        {
            return (max + min) / 2;
        }


        public static int GetProduct(int max,int min)
        {
            return max * min;
        }
    }
}
