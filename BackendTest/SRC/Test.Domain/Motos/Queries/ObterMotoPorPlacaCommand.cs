using Test.Cross.Messages;

namespace Test.Domain.Motos.Queries;

public class ObterMotoPorPlacaCommand : Querie<Moto>
{
    public string Placa { get; set; }

    public ObterMotoPorPlacaCommand(string placa)
    {
        Placa = placa;
    }
}
