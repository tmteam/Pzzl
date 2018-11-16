using System.Diagnostics;
using Pzzl.ConsoleApp.PzzlConfigFile;

namespace Pzzl.ConsoleApp
{
    public class AppLauncher
    {
        private readonly AppUnitConfiguration configuration;

        public AppLauncher(AppUnitConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public PzzlProcess Execute()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = configuration.Command;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = false;
            psi.Arguments = configuration.Argument;
            psi.UseShellExecute = false;
            if (configuration.Mode == Mode.Invisible)
                psi.CreateNoWindow = false;
            var process = Process.Start(psi);
            return new PzzlProcess(configuration, process);
        }
    }
}