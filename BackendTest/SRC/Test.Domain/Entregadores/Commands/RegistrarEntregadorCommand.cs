using Test.Cross.Messages;

namespace Test.Domain.Entregadores.Commands;

public class RegistrarEntregadorCommand : Command
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Cnpj { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public int NumeroCnh { get; private set; }
    public CnhTipo TipoCnh { get; private set; }

    public RegistrarEntregadorCommand()
    {
        
    }
}
