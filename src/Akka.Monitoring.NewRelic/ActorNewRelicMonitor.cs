using System;
using Akka.Monitoring.Impl;

namespace Akka.Monitoring.NewRelic
{
    public class ActorNewRelicMonitor : AbstractActorMonitoringClient
    {
        private readonly Random _random = new Random();

        private bool ShouldSample(double sampleRate)
        {
            return _random.NextDouble() < sampleRate;
        }

        public override void UpdateCounter(string metricName, int delta, double sampleRate)
        {
            if (!ShouldSample(sampleRate)) return;

            global::NewRelic.Api.Agent.NewRelic.RecordMetric($"Custom/{metricName}", delta);
        }

        public override void UpdateTiming(string metricName, long time, double sampleRate)
        {
            if (!ShouldSample(sampleRate)) return;

            global::NewRelic.Api.Agent.NewRelic.RecordResponseTimeMetric($"Custom/{metricName}", time);
        }

        public override void UpdateGauge(string metricName, int value, double sampleRate)
        {
            UpdateCounter(metricName, value, sampleRate);
        }

        //Unique name used to enforce a single instance of this client
        private static readonly int UniqueMonitoringClientId = new Guid("76b65762-8d91-4056-9928-5fed9e1bcda0").GetHashCode();

        public override int MonitoringClientId => UniqueMonitoringClientId;

        public override void DisposeInternal()
        {
            // NOOP
        }
    }
}
