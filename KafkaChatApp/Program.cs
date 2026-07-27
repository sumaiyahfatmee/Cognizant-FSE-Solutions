using Confluent.Kafka;

Console.WriteLine("1. Producer");
Console.WriteLine("2. Consumer");
Console.Write("Choose an option: ");

string? choice = Console.ReadLine();

if (choice == "1")
{
    Console.Write("Enter your name: ");
    string user = Console.ReadLine()!;

    var config = new ProducerConfig
    {
        BootstrapServers = "192.168.1.41:9092"
    };

    using var producer = new ProducerBuilder<Null, string>(config).Build();

    Console.WriteLine("Type messages (type 'exit' to quit):");

    while (true)
    {
        string message = Console.ReadLine()!;

        if (message.ToLower() == "exit")
            break;

        await producer.ProduceAsync("chat-topic", new Message<Null, string>
        {
            Value = $"{user}: {message}"
        });

        Console.WriteLine("Message Sent!");
    }
}
else if (choice == "2")
{
    Consumer.Start();
}
else
{
    Console.WriteLine("Invalid choice.");
}