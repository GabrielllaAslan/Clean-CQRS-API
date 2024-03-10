using Application.Queries.Users.Login.Helpers;
using Application.Validators;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repositories;
using Infrastructure.Repository.BirdRepository;
using Infrastructure.Repository.CatRepository;
using Infrastructure.Repository.DogRepository;
using Infrastructure.Repository.UserRepository;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using API.Controllers;

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
            services.AddScoped<IUserRepository, UserRepository>();

            // Lägg till GuidValidator
            services.AddScoped<GuidValidator>();

            return services;
        }
    }
}
