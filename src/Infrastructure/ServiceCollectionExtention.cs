using CustomerBasketManagement.Domain.Customers.Repository;
using CustomerBasketManagement.Infrastructure.Persistence.Customers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace CustomerBasketManagement.Infrastructure
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(Domain.Common.IRepository<,>), typeof(Persistence.Repository<,>));

            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IDbConnection>((sp) => new SqlConnection(configuration.GetConnectionString("SqlConnection")));

            return services;
        }
    }
}
