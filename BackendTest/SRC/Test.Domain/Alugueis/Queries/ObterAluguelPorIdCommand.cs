using Test.Cross.Messages;

namespace Test.Domain.Alugueis.Services;

public class ObterAluguelPorIdCommand : Querie<Aluguel>
{
    public Guid Id { get; set; }

    public ObterAluguelPorIdCommand(Guid id)
    {
        Id = id;   
    }
}
