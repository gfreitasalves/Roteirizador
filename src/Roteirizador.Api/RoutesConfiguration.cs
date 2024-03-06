using Roteirizador.Application.Abstractions.Commands;
using Roteirizador.Application.Abstractions.Queries;
using Roteirizador.Application.UseCases;
using Roteirizador.Application.UseCases.Interfaces;
using Roteirizador.Infrastructure.Database;

namespace Roteirizador.Api
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //Use cases
            services.AddScoped<ICalcularRotaMaisBarataUseCase, CalcularRotaMaisBarataUseCase>();
            services.AddScoped<IManterRotasUseCase, ManterRotasUseCase>();

            //Repository
            services.AddScoped<IRotaQuery, RotaQuery>();
            services.AddScoped<IRotaRepository, RotaRepository>();

            //Domain
            services.AddScoped<ICalculoRotas, CalculoRotas>();

            return services;
        }
    }
}
