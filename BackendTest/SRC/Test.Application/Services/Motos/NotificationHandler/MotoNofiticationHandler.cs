using MediatR;
using Test.Cross.Kafka;
using Test.Domain.Motos.Evento;

namespace Test.Application.Services.Motos.NotificationHandler;

public class MotoNofiticationHandler : INotificationHandler<MotoAdicionadaEvent>
{
    private readonly IKafkaMessageBus _kafkaMessageBus;

    public MotoNofiticationHandler(IKafkaMessageBus kafkaMessageBus)
    {
        _kafkaMessageBus = kafkaMessageBus;
    }

    public async Task Handle(MotoAdicionadaEvent notification, CancellationToken cancellationToken)
    {
        if(notification.AnoMoto == 2024)
        {
            await _kafkaMessageBus.ProduceAsync("motoCriada", "Moto ano 2024");
        }
    }
}
