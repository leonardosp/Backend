using Test.Cross.Messages;

namespace Test.Domain.Entregadores.Queries;

public class ObterEntregadorPorCnhCommand : Querie<Entregador>
{
    public int Cnh { get; set; }

    public ObterEntregadorPorCnhCommand(int cnh)
    {
        Cnh = cnh;
    }
}
