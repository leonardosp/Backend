using Test.Cross.Messages;

namespace Test.Domain.Motos.Evento;

public class MotoAdicionadaEvent : Event
{
    public Guid MotoId { get; private set; }
    public int AnoMoto { get; private set; }
    public string Modelo { get; private set; }
    public string Placa { get; private set; }

    public MotoAdicionadaEvent(Guid motoId, int anoMoto, string modelo, string placa)
    {
        MotoId = motoId;
        AnoMoto = anoMoto;
        Modelo = modelo;
        Placa = placa;
    }
}
