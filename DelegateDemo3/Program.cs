using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DelegateDemo3
{
   internal delegate String GetStatus();
    class Program
    {
        static void Main(string[] args)
        {

            GetStatus getStatus = null;
            getStatus += new GetStatus(new Light().SwitchPosition);
            getStatus += new GetStatus(new Fan().Speed);
            getStatus += new Speaker().Volume;

            Console.WriteLine(GetComponentStatusReport(getStatus));
        }

        private static String GetComponentStatusReport(GetStatus status)
        {
            // If the chain is empty, there is nothing to do.
            if (status == null) return null;
            // Use this to build the status report.
            StringBuilder report = new StringBuilder();
            // Get an array where each element is a delegate from the chain.
            Delegate[] arrayOfDelegates = status.GetInvocationList();
            // Iterate over each delegate in the array.
            foreach (GetStatus getStatus in arrayOfDelegates)
            {
                try
                {
                    // Get a component's status string, and append it to the report.
                    report.AppendFormat("{0}{1}{1}", getStatus(), Environment.NewLine);
                }
                catch (InvalidOperationException e)
                {
                    // Generate an error entry in the report for this component.
                    Object component = getStatus.Target;
                    report.AppendFormat( "Failed to get status from {1}{2}{0} Error: {3}{0}{0}",Environment.NewLine,((component == null) ? "" : component.GetType() + "."),getStatus.Method.Name,e.Message);
                }
            }
            // Return the consolidated report to the caller.
            return report.ToString();
        }
    }

    // Define a Light component.
    internal sealed class Light
    {
        // This method returns the light's status.
        public String SwitchPosition()
        {
            return "The light is off";
        }
    }
    // Define a Fan component.
    internal sealed class Fan
    {
        // This method returns the fan's status.
        public String Speed()
        {
            throw new InvalidOperationException("The fan broke due to overheating");
        }
    }
    // Define a Speaker component.
    internal sealed class Speaker
    {
        // This method returns the speaker's status.
        public String Volume()
        {
            return "The volume is loud";
        }
    }
}
