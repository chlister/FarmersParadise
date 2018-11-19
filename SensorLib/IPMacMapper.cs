using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorLib
{
    class IPMacMapper
    {
        private static List<IPAndMac> list;

        private static StreamReader ExecuteCommandLine(String file, String arguments = "")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = file;
            startInfo.Arguments = arguments;

            Process process = Process.Start(startInfo);

            return process.StandardOutput;
        }

        private static void InitializeGetIPsAndMac()
        {
            if (list != null)
            {
                list.Clear();
            }

            // executes a arp request
            var arpStream = ExecuteCommandLine("arp", "-a");
            List<string> result = new List<string>();
            while (!arpStream.EndOfStream)
            {
                // add all entries to the list result
                var line = arpStream.ReadLine().Trim();
                result.Add(line);
            }

            /*
             * finds the strings from the list where they are:
             * not null
             * contains either dynamic or static
             * then splits those into an array containing only IP and MAC address
             * */

            list = result.Where(x => !string.IsNullOrEmpty(x) && (x.Contains("dynamic") || x.Contains("static")))
                .Select(x =>
                {
                    string[] parts = x.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    return new IPAndMac { IP = parts[0].Trim(), MAC = parts[1].Trim() };
                }).ToList();
        }

        /// <summary>
        /// Given a MAC address will find it IP counterpart
        /// If none is found, returns NULL
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns></returns>
        public static string FindIPFromMacAddress(string macAddress)
        {
            InitializeGetIPsAndMac();
            IPAndMac m = list.SingleOrDefault(x => x.MAC == macAddress);
            if (m == null)
                return null;
            return m.IP;
        }

        /// <summary>
        /// Given a IP address will find the IP counterpart
        /// If none is found, returns NULL
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string FindMacFromIPAddress(string ip)
        {
            InitializeGetIPsAndMac();
            return list.SingleOrDefault(x => x.IP == ip).MAC;
        }

        private class IPAndMac
        {
            public string IP { get; set; }
            public string MAC { get; set; }
        }
    }
}
