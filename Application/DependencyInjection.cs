using Application.Queries.Users.Login.Helpers;
using FluentValidation;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repositories.Cats;
using Infrastructure.Repository.BirdRepository;
using Infrastructure.Repository.CatRepository;
using Infrastructure.Repository.DogRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            services.AddScoped<TokenHelper>();

            services.AddValidatorsFromAssembly(assembly);

            services.AddScoped<IBirdRepository, BirdRepository>();

            services.AddScoped<IDogRepository, DogRepository>();
            
            services.AddScoped<ICatRepository, CatRepository>();

            return services;
        }
    }
}
