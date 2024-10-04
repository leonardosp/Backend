using Test.Cross.Messages;

namespace Test.Domain.Entregadores.Service;

public class ObterEntregadorPorIdCommand : Querie<Entregador>
{
    public Guid Id { get; set; }

    public ObterEntregadorPorIdCommand(Guid id)
    {
        Id = id;
    }
}
