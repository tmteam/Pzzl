using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;
using Pzzl.ConsoleApp.PzzlConfigFile;

namespace Pzzl.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("begin");
            var config = PzzlConfigReader.Read("Base.pzzl");
            List<PzzlProcess> processes = new List<PzzlProcess>();

            foreach (var appUnitConfiguration in config.Puzzles)
            {
                Console.WriteLine("--------------");
                Console.WriteLine("starting "+ appUnitConfiguration.Name + "...");
                var launcher = new AppLauncher(appUnitConfiguration);
                processes.Add(launcher.Execute());
                
                Console.WriteLine("Started");
            }

            InfineRedraw(processes).Wait();
            Console.WriteLine("end");
        }

        private static async Task InfineRedraw(IEnumerable<PzzlProcess> processes)
        {
            while (true)
            {
                Redraw(processes);
                await Task.Delay(200);
            }
        }
        private static void Redraw(IEnumerable<PzzlProcess>processes)
        {
            Console.Clear();
            foreach (var process in processes)
            {
                Console.WriteLine($"| {process.Configuration.Name:10} " +
                                  $"| {(process.IsStarted?"Started":"Closed"): 8} " +
                                  $"| {process.LaunchedAt.ToShortTimeString(): 10} " +
                                  $"| {(process.FinishedAt.HasValue?process.FinishedAt.Value.ToShortTimeString():"---"):10]}"+
                                  $"| {(process.Configuration.Mode == Mode.Visible?"": "HIDDEN"):10}");
            }
        }
        
    }
}