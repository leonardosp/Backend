using Test.Cross.Messages;

namespace Test.Domain.Entregadores.Queries;

public class ObterEntregadorPorCnpjCommand : Querie<Entregador>
{
    public string Cnpj { get; set; }

    public ObterEntregadorPorCnpjCommand(string cnpj)
    {
        Cnpj = cnpj;
    }
}
