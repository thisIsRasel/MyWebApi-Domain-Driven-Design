using Application.CreateBook;
using Application.SendEvent;
using Application.SendMessage;
using GraphiQl;
using Infrastructure;
using MassTransit;
using NServiceBus;
using WebService.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();

builder.Host.UseNServiceBus(context =>
 {
     var endpointConfiguration = new EndpointConfiguration("WebService");
     var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
     transport.ConnectionString("amqp://guest:guest@localhost:5672/");
     transport.UseConventionalRoutingTopology();

     var routing = transport.Routing();
     routing.RouteToEndpoint(typeof(SendMessageCommand), "Host");

     return endpointConfiguration;
 });

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<TestMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.UseGraphiQl("/graphql");

app.Run();
