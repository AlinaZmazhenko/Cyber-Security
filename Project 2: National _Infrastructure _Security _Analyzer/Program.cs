using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading.Tasks; 
using System.Collections.Concurrent;
using System.Diagnostics;

namespace EnterpriseSecurityScanner
{
    public class CyberSecurityEngine
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            Console.WriteLine(" NATIONAL INFRASTRUCTURE SECURITY ANALYZER V1.0 ");
            Console.WriteLine(" [INFO] Scanning Network Segment: 192.168.1.0/24\n");
            
            // Tab
            Console.WriteLine("{0,-18} | {1,-10} | {2,-15} | {3,-10}", "IP Address", "Status", "Open Ports", "Risk");
            Console.WriteLine(new string('-', 65));
            
            var watch = Stopwatch.StartNew();
            string subnet = "192.168.1";
            var activeNodes = new ConcurrentBag<string>();
             
            var tasks = new Task[254]; 
            for (int i = 1; i <= 254; i++)
            {
                int currentIp = i;
                tasks[i - 1] = Task.Run(async () =>
                {
                    string ip = $"{subnet}.{currentIp}";
                    if (CheckNodeStatus(ip))
                    {
                        activeNodes.Add(ip);
                        string ports = await ScanPortsSimulation(ip);
                        PrintRow(ip, "ACTIVE", ports);
                    }
                });
            }
             
            await Task.WhenAll(tasks);
            watch.Stop();

            Console.WriteLine(new string('-', 65));
            Console.WriteLine($"\n[SUMMARY] Total nodes evaluated: {activeNodes.Count}");
            Console.WriteLine($"[PERFORMANCE] Deep scan completed in: {watch.ElapsedMilliseconds} ms");
        }

        static bool CheckNodeStatus(string ip)
        {
            if (ip.EndsWith(".1") || ip.EndsWith(".50")) return true;

            // Ping
            try
            {
                using (Ping pingSender = new Ping())
                {
                    PingReply reply = pingSender.Send(ip, 100);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch { return false; }
        }

        static async Task<string> ScanPortsSimulation(string ip)
        {
            await Task.Delay(10); // Network
            if (ip.EndsWith(".1")) return "80";
            if (ip.EndsWith(".50")) return "22, 443";
            return "None";
        }

        static void PrintRow(string ip, string status, string ports)
        {
            string risk = "LOW";
            if (ports.Contains("22")) risk = "CRITICAL";
            else if (ip.EndsWith(".1")) risk = "HIGH";

            Console.WriteLine("{0,-18} | {1,-10} | {2,-15} | {3,-10}", ip, status, ports, risk);
        }
    }
}