using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DelegateDemo5
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    internal sealed class AClass
    {
        public static void UsingLocalVariablesInTheCallbackCode(Int32 numToDo)
        {
            // Some local variables
            Int32[] squares = new Int32[numToDo];
            AutoResetEvent done = new AutoResetEvent(false);
            // Do a bunch of tasks on other threads
            for (Int32 n = 0; n < squares.Length; n++)
            {
                ThreadPool.QueueUserWorkItem(
                obj => {
                    Int32 num = (Int32)obj;
                    
                // This task would normally be more time consuming
                squares[num] = num * num;
                // If last task, let main thread continue running
                if (Interlocked.Decrement(ref numToDo) == 0)
                        done.Set();
                },
                n);
            }
            // Wait for all the other threads to finish
            done.WaitOne();
            // Show the results
            for (Int32 n = 0; n < squares.Length; n++)
                Console.WriteLine("Index {0}, Square={1}", n, squares[n]);
        }
    }
}

