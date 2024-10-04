using FluentValidation.Results;
using MediatR;
using Test.Cross.Messages;
using Test.Domain.Entregadores.Interface;

namespace Test.Domain.Entregadores.Commands.Handler;

public class EntregadorCommandHandler : CommandHandler,
             IRequestHandler<RegistrarEntregadorCommand, ValidationResult>,
             IRequestHandler<AtualizarFotoEntregadorCommand, ValidationResult>
{
    private readonly IEntregadorRepository _entregadorRepository;

    public EntregadorCommandHandler(IEntregadorRepository entregadorRepository)
    {
        _entregadorRepository = entregadorRepository;
    }

    public async Task<ValidationResult> Handle(RegistrarEntregadorCommand request, CancellationToken cancellationToken)
    {
        var entregador = new Entregador(request.Nome, request.Cnpj, request.DataNascimento, request.DataCadastro, request.NumeroCnh, request.TipoCnh);

        _entregadorRepository.Adicionar(entregador);

        return await PersistirDados(_entregadorRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(AtualizarFotoEntregadorCommand request, CancellationToken cancellationToken)
    {
        var entregador = await _entregadorRepository.ObterPorId(request.Id);

        entregador.SetarImagem(request.Imagem);

        _entregadorRepository.Atualizar(entregador);

        return await PersistirDados(_entregadorRepository.UnitOfWork);
    }
}
