using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

public class ServiceBusPublisher
{
    private readonly string _connectionString;

    private readonly string _queueName;

    public ServiceBusPublisher(IConfiguration configuration)
    {
        _connectionString = configuration["AzureServiceBus:ConnectionString"]
                            ?? throw new ArgumentNullException(nameof(configuration), "AzureServiceBus:ConnectionString is not configured.");

        _queueName = configuration["AzureServiceBus:QueueName"]
                     ?? throw new ArgumentNullException(nameof(configuration), "AzureServiceBus:QueueName is not configured.");
    }

    public async Task SendMessageAsync(object messageContent)
    {
        await using var client = new ServiceBusClient(_connectionString);
        ServiceBusSender sender = client.CreateSender("motorcycle.created");

        try
        {
            ServiceBusMessage message = new(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(messageContent)));
            await sender.SendMessageAsync(message);
            Console.WriteLine($"Mensagem enviada: {_connectionString} + {_queueName} + {message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao enviar mensagem: {ex.Message}");
        }
    }
}