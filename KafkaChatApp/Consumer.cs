using Confluent.Kafka;

public class Consumer
{
    public static void Start()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "192.168.1.41:9092",
            GroupId = "chat-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

        consumer.Subscribe("chat-topic");

        Console.WriteLine("Listening for messages...");

        while (true)
        {
            var result = consumer.Consume();
            Console.WriteLine(result.Message.Value);
        }
    }
}