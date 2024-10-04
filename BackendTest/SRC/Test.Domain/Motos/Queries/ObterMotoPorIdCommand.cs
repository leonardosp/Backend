using Test.Cross.Messages;

namespace Test.Domain.Motos.Queries;

public class ObterMotoPorIdCommand : Querie<Moto>
{
    public Guid Id { get; set; }

    public ObterMotoPorIdCommand(Guid id)
    {
        Id = id;
    }
}
