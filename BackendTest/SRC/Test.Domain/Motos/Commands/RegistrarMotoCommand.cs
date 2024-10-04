using Test.Cross.Messages;

namespace Test.Domain.Motos.Commands;

public class RegistrarMotoCommand : Command
{
    public int Ano { get; private set; }
    public string Modelo { get; private set; }
    public string Placa { get; private set; }

    public RegistrarMotoCommand()
    {
        
    }

    public RegistrarMotoCommand(int ano, string modelo, string placa)
    {
        Ano = ano;
        Modelo = modelo;
        Placa = placa;
    }
}
