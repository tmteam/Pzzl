using System;
using System.Diagnostics;
using Pzzl.ConsoleApp.PzzlConfigFile;

namespace Pzzl.ConsoleApp
{
    public class PzzlProcess
    {
        private readonly Process process;

        public PzzlProcess(AppUnitConfiguration configuration, Process process)
        {
            this.Configuration = configuration;
            this.process = process;
            
        }
        
        public void Stop()
        {
            process.Kill();
        }
        
        public AppUnitConfiguration Configuration { get; }
        public DateTime LaunchedAt => process.StartTime;
        public DateTime? FinishedAt => IsStarted?(DateTime?)null: process.ExitTime;

        public bool IsStarted => !process.HasExited;
    }
}