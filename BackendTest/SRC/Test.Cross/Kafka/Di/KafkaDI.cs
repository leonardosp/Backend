using Microsoft.Extensions.DependencyInjection;

namespace Test.Cross.Kafka.Di;

public static class KafkaDI
{
    public static IServiceCollection RegisterKafka(this IServiceCollection services, string connection)
    {
        if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException();

        services.AddSingleton<IKafkaMessageBus>(new KafkaMessageBus(connection));

        return services;
    }
}
