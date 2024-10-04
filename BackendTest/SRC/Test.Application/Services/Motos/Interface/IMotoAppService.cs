using FluentValidation.Results;
using Test.Application.Models;

namespace Test.Application.Services.Motos.Interface;

public interface IMotoAppService : IDisposable
{
    public Task<ValidationResult> RegistrarMoto(MotoViewModel motoViewModel);
    public Task<MotoViewModel> ObterMotoPorPlaca(string placa);
    public Task<MotoViewModel> ObterMotoPorId(Guid id);
    public Task<ValidationResult> RemoverMotoPorId(Guid id);
    public Task<ValidationResult> AtualizarPlacaMoto(Guid id, string placa);

}
