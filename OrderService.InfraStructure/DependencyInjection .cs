using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Core.Interfaces;
using OrderService.InfraStructure.Context;
using OrderService.InfraStructure.Repository;

namespace OrderService.InfraStructure
{
    public static class DependencyInjection 
    {
         public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
         {

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });  
            return services;
 
        }
    }
}
