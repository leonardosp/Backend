using FluentValidation.Results;
using Test.Application.Models;

namespace Test.Application.Services.Entregador.Interface;

public interface IEntregadorAppService : IDisposable
{
    public Task<ValidationResult> RegistrarEntregador(EntregadorViewModel entregadorViewModel);
    public Task<ValidationResult> AtualizarFotoEntregador(AtualizarFotoEntregadorViewModel entregadorViewModel);
    public Task<EntregadorViewModel> ObterPorCnh(int cnh);
    public Task<EntregadorViewModel> ObterPorCnpj(string cnpj);
    public Task<EntregadorViewModel> ObterPorId(Guid id);
}
