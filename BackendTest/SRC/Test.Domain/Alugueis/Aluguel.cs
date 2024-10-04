using Test.Cross.Utils;
using Test.Domain.Entregadores;
using Test.Domain.Motos;

namespace Test.Domain.Alugueis;

public class Aluguel : Entity
{
    public DateTime DataInicio { get; private set; }
    public DateTime DataTermino { get; private set; }
    public DateTime DataPrevisaoFim { get; private set; }
    public DateTime DataDevolucao { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public decimal ValorTotal { get; private set; }
    public decimal? ValorPrevisto { get; private set; }
    public Entregador Entregador { get; set; }
    public Moto Moto { get; set; }

    public Aluguel(DateTime dataInicio, DateTime dataTermino, DateTime dataPrevisaoFim, DateTime dataDevolucao)
    {
        DataInicio = dataInicio;
        DataTermino = dataTermino;
        DataPrevisaoFim = dataPrevisaoFim;
        DataDevolucao = dataDevolucao;
    }
}
