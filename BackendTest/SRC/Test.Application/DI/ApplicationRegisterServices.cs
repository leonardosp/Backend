using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Test.Application.Services.Aluguel;
using Test.Application.Services.Aluguel.Interface;
using Test.Application.Services.Entregador;
using Test.Application.Services.Entregador.Interface;
using Test.Application.Services.Motos;
using Test.Application.Services.Motos.Interface;
using Test.Application.Services.Motos.NotificationHandler;
using Test.Cross.Mediator;
using Test.Domain.Motos.Evento;

namespace Test.Application.DI;

public static class ApplicationRegisterServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IEntregadorAppService, EntregadorAppService>();
        services.AddTransient<IAluguelAppService, AluguelAppService>();
        services.AddTransient<IMotoAppService, MotoAppService>();
        services.AddScoped<INotificationHandler<MotoAdicionadaEvent>, MotoNofiticationHandler>();
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        return services;
    }
}
