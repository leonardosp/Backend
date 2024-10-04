using Microsoft.Extensions.DependencyInjection;
using Test.Domain.Alugueis.Interface;
using Test.Domain.Entregadores.Interface;
using Test.Domain.Motos.Interface;
using Test.Infra.Repository.Alugueis;
using Test.Infra.Repository.Entregadores;
using Test.Infra.Repository.Motos;

namespace Test.Infra.DI;

public static class RepositoryDependencyInject
{
    public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IAluguelRepository, AluguelRepository>();
        services.AddScoped<IEntregadorRepository, EntregadorRepository>();
        services.AddScoped<IMotoRepository, MotoRepository>();

        services.AddScoped<BackendeTestContext>();

        return services;
    }
}