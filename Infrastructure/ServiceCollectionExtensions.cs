using Application.CreateBook;
using Domain;
using Domain.AggregatesModel.BookAggregate;
using Domain.AppSettings;
using Infrastructure.DbContext;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(
            this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();

            var appSettings = new AppSettings();
            configuration.Bind(appSettings);
            services.AddSingleton(appSettings);

            services.AddTransient<IMongoContext, MongoContext>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(typeof(CreateBookCommandHandler).Assembly);
            services.AddTransient<IBookWriteRepository, BookRepository>();
            services.AddTransient<IBookReadRepository, BookRepository>();
        }
    }
}
