using Test.Cross.Messages;

namespace Test.Domain.Alugueis.Commands;

public class RegistrarAluguelCommand : Command
{
    public DateTime DataInicio { get; private set; }
    public DateTime DataTermino { get; private set; }
    public DateTime DataPrevisaoFim { get; private set; }
    public DateTime DataDevolucao { get; private set; }
    public decimal ValorTotal { get; private set; }
    public decimal? ValorPrevisto { get; private set; }

    public Guid IdEntregador { get; private set; }
    public Guid IdMoto { get; private set; }

    public RegistrarAluguelCommand()
    {

    }
}
