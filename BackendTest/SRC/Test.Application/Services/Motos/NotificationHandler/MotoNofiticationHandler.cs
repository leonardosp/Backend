using MediatR;
using Test.Domain.Motos.Evento;

namespace Test.Application.Services.Motos.NotificationHandler;

public class MotoNofiticationHandler : INotificationHandler<MotoAdicionadaEvent>
{
    public Task Handle(MotoAdicionadaEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
