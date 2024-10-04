using Test.Cross.Messages;

namespace Test.Domain.Alugueis.Queries;

public class ObterAluguelPorMotoIdCommand : Querie<Aluguel>
{
    public Guid MotoId { get; set; }
}
