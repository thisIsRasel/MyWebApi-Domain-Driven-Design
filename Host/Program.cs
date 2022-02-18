// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using NServiceBus;

var builder = Host.CreateDefaultBuilder(args);

await builder.UseNServiceBus(context =>
 {
     var endpointConfiguration = new EndpointConfiguration("Host");
     var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
     transport.ConnectionString("amqp://guest:guest@localhost:5672/");
     transport.UseConventionalRoutingTopology();

     return endpointConfiguration;
 }).Build().RunAsync();
