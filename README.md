# Akka.Monitoring.NewRelic

[Monitoring system instrumentation](https://github.com/petabridge/akka-monitoring) in New Relic for [Akka.NET](https://github.com/akkadotnet/akka.net) actor systems.

## Quickstart

Add the `Akka.Monitoring.NewRelic` package to your project:

```bash
dotnet add package Akka.Monitoring.NewRelic
```

Then instrument your actor system as normal.

From [PlutoActor](src/Akka.Monitoring.NewRelic.Demo/PlutoActor.cs):
```csharp
Receive<string>(_ =>
{
    Context.IncrementCounter("revolutions");
    Context.GetLogger().Debug("Whee!");
    Context.Gauge("revolutions.enjoyment", random.Next(1, 11));
});
```

For more information on instrumenting [Akka.NET](https://github.com/akkadotnet/akka.net) actor systems, please see [Akka.Monitoring](https://github.com/petabridge/akka-monitoring).

## Building

[![Travis](https://img.shields.io/travis/syncromatics/Akka.Monitoring.NewRelic.svg)](https://travis-ci.org/syncromatics/Akka.Monitoring.NewRelic)
[![NuGet](https://img.shields.io/nuget/v/Akka.Monitoring.NewRelic.svg)](https://www.nuget.org/packages/Akka.Monitoring.NewRelic/)
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Akka.Monitoring.NewRelic.svg)](https://www.nuget.org/packages/Akka.Monitoring.NewRelic/)

The package targets .NET Standard 2.0 and can be built via [.NET Core](https://www.microsoft.com/net/core):

```bash
dotnet build
```

Because the standard New Relic agent (as of verion 6.18.139.0) does not (yet) support instrumenting .NET Core apps, the [demo program](src/Akka.Monitoring.NewRelic.Demo) targets .NET Framework 4.6.2.

## Code of Conduct

We are committed to fostering an open and welcoming environment. Please read our [code of conduct](CODE_OF_CONDUCT.md) before participating in or contributing to this project.

## Contributing

We welcome contributions and collaboration on this project. Please read our [contributor's guide](CONTRIBUTING.md) to understand how best to work with us.

## License and Authors

[![Syncromatics Engineering logo](https://en.gravatar.com/userimage/100017782/89bdc96d68ad4b23998e3cdabdeb6e13.png?size=16) Syncromatics Engineering](https://github.com/syncromatics)

[![license](https://img.shields.io/github/license/syncromatics/Akka.Monitoring.NewRelic.svg)](https://github.com/syncromatics/Akka.Monitoring.NewRelic/blob/master/LICENSE)
[![GitHub contributors](https://img.shields.io/github/contributors/syncromatics/Akka.Monitoring.NewRelic.svg)](https://github.com/syncromatics/Akka.Monitoring.NewRelic/graphs/contributors)

This software is made available by Syncromatics Engineering under the MIT license.