using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Test.Domain.Alugueis;
using Test.Domain.Alugueis.Commands;
using Test.Domain.Alugueis.Commands.Handler;
using Test.Domain.Alugueis.Queries;
using Test.Domain.Alugueis.Services;
using Test.Domain.Alugueis.Services.Repository;
using Test.Domain.Entregadores;
using Test.Domain.Entregadores.Commands;
using Test.Domain.Entregadores.Commands.Handler;
using Test.Domain.Entregadores.Queries;
using Test.Domain.Entregadores.Service;
using Test.Domain.Entregadores.Service.Repository;
using Test.Domain.Motos;
using Test.Domain.Motos.Commands;
using Test.Domain.Motos.Commands.Handler;
using Test.Domain.Motos.Queries;
using Test.Domain.Motos.Queries.Handler;
using Test.Domain.Paged;

namespace Test.Domain.DI;

public static class DomainRegisterCommands
{
    public static IServiceCollection RegisterDomainCommands(this IServiceCollection services)
    {
        //Entregadores
        services.AddScoped<IRequestHandler<RegistrarEntregadorCommand, ValidationResult>, EntregadorCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarFotoEntregadorCommand, ValidationResult>, EntregadorCommandHandler>();
        services.AddScoped<IRequestHandler<ObterEntregadorPorCnhCommand, Entregador>, EntregadorQueriesHandler>();
        services.AddScoped<IRequestHandler<ObterEntregadorPorCnpjCommand, Entregador>, EntregadorQueriesHandler>();
        services.AddScoped<IRequestHandler<ObterEntregadorPorIdCommand, Entregador>, EntregadorQueriesHandler>();
        services.AddScoped<IRequestHandler<ObterTodosEntregadoresCommand, PagedResult<Entregador>>, EntregadorQueriesHandler>();

        //Aluguel
        services.AddScoped<IRequestHandler<RegistrarAluguelCommand, ValidationResult>, AluguelCommandHandler>();
        services.AddScoped<IRequestHandler<ObterAluguelPorIdCommand, Aluguel>, AluguelQueriesHandler>();
        services.AddScoped<IRequestHandler<ObterAluguelPorMotoIdCommand, Aluguel>, AluguelQueriesHandler>();

        //Moto
        services.AddScoped<IRequestHandler<RegistrarMotoCommand, ValidationResult>, MotoCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarMotoCommand, ValidationResult>, MotoCommandHandler>();
        services.AddScoped<IRequestHandler<RemoverMotoCommand, ValidationResult>, MotoCommandHandler>();
        services.AddScoped<IRequestHandler<ObterMotoPorIdCommand, Moto>, MotoQueriesHandler>();
        services.AddScoped<IRequestHandler<ObterMotoPorPlacaCommand, Moto>, MotoQueriesHandler>();

        return services;
    }
}
