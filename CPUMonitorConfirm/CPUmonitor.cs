using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Management;

namespace CPUMonitorConfirm
{
    class CPUmonitor
    {
        //check cpu upper and lower limit
        public static void check(string[] args)
        {
            //var lower = args[0];
            //var upper = args[1];
            //var username = args[2];
            //var password = args[3];
            var coreValues = cpuCounter();
            //cpuCompare(coreValues, args[0], args[1]);
            cpuCompare(coreValues, "35", "95");
        }

        private static List<object> cpuCounter()
        {
            var coreValues = new List<object>();
            ManagementObjectSearcher processor = 
                new ManagementObjectSearcher("root\\CIMV2",
                "SELECT PercentProcessorTime FROM Win32_PerfFormattedData_Counters_ProcessorInformation");
            foreach(ManagementObject query in processor.Get())
            {
                coreValues.Add(query["PercentProcessorTime"]);
                Console.WriteLine("CPU %{0}",query["PercentProcessorTime"]);
                //first two values are 1.total % across all processors 2.total %
            }
            return coreValues;
        }    
        
        private static int cpuCompare(List<object> coreValues, string lower, string upper)
        {
            var value = 0; //return value
            var totCore = 0; //total core %
            int x = 0; //counter
            var low = Convert.ToInt16(lower);
            var high = Convert.ToInt16(upper);

            //ignore first two values, grab actual core count and subtract from coreValues.count
            var measured = coreValues.Count;
            var actual = Environment.ProcessorCount;
            var diff = measured - actual;

            foreach(var item in coreValues)
            {//get total core averages make sure you ignore the first 2 values as
                if (!(x == 0 || x == 1))
                    totCore = totCore + Convert.ToInt16(item);
                x++;
            }
            totCore = totCore / actual;

            if (!(totCore > low && totCore < high))
            {
                //return error
                value = totCore;
            }
            return value;
        }   
    }
}
