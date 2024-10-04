using Test.Cross.Messages;

namespace Test.Domain.Entregadores.Commands;

public class AtualizarFotoEntregadorCommand : Command
{
    public Guid Id { get; private set; }
    public string Imagem { get; private set; }

    public AtualizarFotoEntregadorCommand()
    {
        
    }

    public AtualizarFotoEntregadorCommand(Guid id, string imagem)
    {
        Id = id;
        Imagem = imagem;
    }
}
