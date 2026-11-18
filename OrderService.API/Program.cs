using OrderService.InfraStructure;
using OrderService.Core;
using OrderService.Core.MiddileWare;
using Microsoft.Extensions.DependencyInjection;

namespace OrderService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInfraStructure(builder.Configuration);
            builder.Services.AddCore(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();
            app.UseMiddleware<ExceptionMiddleware>();
            app.Run();
        }
    }
}
