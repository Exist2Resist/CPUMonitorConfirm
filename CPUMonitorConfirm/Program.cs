using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUMonitorConfirm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(args[0]);            
            //args takes 4 arguments (lower cpu limit, upper cpu limit, user name, password)
            //if (args.Length != 4)
            //{
            //    Console.WriteLine("Invalid number of parameter switches!");
            //    Environment.Exit(2);
            //}
            //else
            //{
                //PRTG requires an exit code
                //value = CPUmonitor.check(args);
                CPUmonitor.check(args);
                //Environment.Exit((int)value[0]);
                Console.ReadLine();
                Environment.Exit(0);
            //}
        }
    }
}
//Exit codes for PRTG
//Success = 0,
//WARNING = 1,
//System_Error = 2,
//Protocol_Error = 3,
//Content_Error = 4
