using FluentValidation.Results;
using Test.Application.Models;

namespace Test.Application.Services.Aluguel.Interface;

public interface IAluguelAppService : IDisposable
{
    public Task<ValidationResult> RegistrarAluguel(AluguelViewModel aluguelViewModel);
    public Task<AluguelViewModel> ObterAluguelPorId(Guid id);
    public Task<AluguelViewModel> ObterValorAluguel(Guid id, DateTime dataDevolucao);
}
