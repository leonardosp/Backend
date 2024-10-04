using Test.Cross.Messages;

namespace Test.Domain.Motos.Commands;

public class RemoverMotoCommand : Command
{
    public Guid Id { get; set; }

    public RemoverMotoCommand(Guid id)
    {
        Id = id;
    }
}
