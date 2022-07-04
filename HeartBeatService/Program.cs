using System;
using Topshelf;

/// <summary>
/// To run as window service, input "HeartBeatService.exe install start" in cmd
/// To uninstall, input "HeartBeatService.exe uninstall" in cmd
/// 
/// Service will generate a .txt file in project output folder 
/// </summary>
namespace HeartBeatService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitcode = HostFactory.Run(x =>
            {
                x.Service<Heartbeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new Heartbeat());
                    s.WhenStarted(heartbeat => heartbeat.Start());
                    s.WhenStopped(heartbeat => heartbeat.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("HeartbeatService");
                x.SetDisplayName("Heartbeat Service");
                x.SetDescription("Sample heartbeat service");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitcode, exitcode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
