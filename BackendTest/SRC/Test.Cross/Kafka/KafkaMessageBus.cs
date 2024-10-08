using Confluent.Kafka;
using System.Text.Json;

namespace Test.Cross.Kafka;

internal class KafkaMessageBus : IKafkaMessageBus
{
    private readonly string _bootstrapserver;

    public KafkaMessageBus(string bootstrapserver)
    {
        _bootstrapserver = bootstrapserver;
    }

    public async Task ProduceAsync<T>(string topic, T message) where T : class
    {
        var config = new ProducerConfig
        {
            BootstrapServers = _bootstrapserver
        };

        var payload = JsonSerializer.Serialize(message);

        var producer = new ProducerBuilder<string, string>(config).Build();

        var result = await producer.ProduceAsync(topic, new Message<string, string>
        {
            Key = Guid.NewGuid().ToString(),
            Value = payload
        });

        await Task.CompletedTask;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
