namespace Test.Cross.Kafka;

public interface IKafkaMessageBus : IDisposable
{
    Task ProduceAsync<T>(string topic, T message) where T : class;
}
