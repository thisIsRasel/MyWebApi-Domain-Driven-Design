// See https://aka.ms/new-console-template for more information
using Application.SendEvent;
using MassTransit;
using Microsoft.Extensions.Hosting;
using NServiceBus;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(async services =>
{
    var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("MassTransitHost", e =>
        {
            e.Consumer<SendEventConsumer>();
        });
    });

    using var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

    await busControl.StartAsync(source.Token);
    try
    {
        Console.WriteLine("Press enter to exit");

        await Task.Run(() => Console.ReadLine());
    }
    finally
    {
        await busControl.StopAsync();
    }
});

builder.UseNServiceBus(context =>
 {
     var endpointConfiguration = new EndpointConfiguration("Host");
     var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
     transport.ConnectionString("amqp://guest:guest@localhost:5672/");
     transport.UseConventionalRoutingTopology();

     return endpointConfiguration;
 });

await builder.Build().RunAsync();

