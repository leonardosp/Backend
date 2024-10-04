using Test.Cross.Messages;

namespace Test.Domain.Motos.Commands;

public class AtualizarMotoCommand : Command
{
    public Guid Id { get; set; }
    public string Placa { get; set; }

    public AtualizarMotoCommand(Guid id, string placa)
    {
        Id = id;
        Placa = placa;
    }
}
