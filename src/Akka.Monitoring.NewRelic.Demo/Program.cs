using System;
using System.Threading;
using Akka.Actor;

namespace Akka.Monitoring.NewRelic.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Starting up actor system...");
            var system = ActorSystem.Create("akka-performance-demo");

            var didMonitorRegister = ActorMonitoringExtension.RegisterMonitor(system, new ActorNewRelicMonitor());
            Console.WriteLine(didMonitorRegister
                ? "Successfully registered NewRelic monitor"
                : "Failed to register New Relic monitor");

            // Start up three sets of Pluto and Charon (reference to I'm Your Moon by Jonathan Coulton)
            for (var i = 0; i < 3; i++)
            {
                var pluto = system.ActorOf<PlutoActor>();
                var charon = system.ActorOf<CharonActor>();
                charon.Tell(pluto); 
            }

            Console.WriteLine("Waiting 60 seconds so the New Relic agent has time to harvest metrics");
            Thread.Sleep(TimeSpan.FromSeconds(60));

            Console.WriteLine("Shutting down...");
            system.Terminate().Wait();
            Console.WriteLine("Shutdown complete");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
