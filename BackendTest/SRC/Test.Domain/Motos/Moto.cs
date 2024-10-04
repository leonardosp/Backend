using Test.Cross.Utils;
using Test.Domain.Alugueis;

namespace Test.Domain.Motos;

public class Moto : Entity
{
    public int Ano { get; private set; }
    public string Modelo { get; private set; }
    public string Placa { get; private set; }
    public bool Excluido { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public IEnumerable<Aluguel> Alugueis { get; set; }

    public Moto(int ano, string modelo, string placa)
    {
        Ano = ano;
        Modelo = modelo;
        Placa = placa;
        Excluido = false;
    }

    public void Excluir()
    {
        Excluido = true;
    }

    public void AlterarPlaca(string placa)
    {
        Placa = placa;
    }
}
