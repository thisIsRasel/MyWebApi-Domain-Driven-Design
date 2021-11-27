using Application.CreateBook;
using Domain;
using Domain.AggregatesModel.BookAggregate;
using Infrastructure.DbContext;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(
            this IServiceCollection services)
        {
            services.AddTransient<IMongoContext, MongoContext>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddMediatR(typeof(CreateBookCommandHandler).Assembly);
            services.AddTransient<IBookWriteRepository, BookWriteRepository>();
        }
    }
}
