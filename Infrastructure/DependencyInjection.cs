using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddSingleton<MockDatabase>();
            services.AddDbContext<RealDatabase>(option =>
            {
                option.UseSqlServer("Server=LAPTOP-O7CREI7D; Database=claen-api; Trusted_Connection=True; TrustServerCertificate=True");
            });

            return services;
        }
    }
}
