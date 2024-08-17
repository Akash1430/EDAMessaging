using Azure.Messaging.ServiceBus;
using System.Text;
using System.Threading.Tasks;
using System;

namespace EDA_Messaging
{
    public class EventConsumer
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusProcessor _processor;

        public EventConsumer(string connectionString, string queueName)
        {
            _client = new ServiceBusClient(connectionString);
            _processor = _client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
        }

        public async Task StartProcessingAsync()
        {
            _processor.ProcessMessageAsync += ProcessMessageHandler;
            _processor.ProcessErrorAsync += ProcessErrorHandler;
            await _processor.StartProcessingAsync();
        }

        private Task ProcessMessageHandler(ProcessMessageEventArgs args)
        {
            var messagingMessage = args.Message.Body.ToArray();
            var message = Encoding.UTF8.GetString(messagingMessage);
            Console.WriteLine($"Received message: {message}");
            return Task.CompletedTask;
        }

        private Task ProcessErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine($"Error occurred: {args.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}
