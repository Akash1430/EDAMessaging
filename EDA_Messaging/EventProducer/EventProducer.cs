using Azure.Messaging.ServiceBus;
using System.Text;
using System.Threading.Tasks;

namespace EDA_Messaging
{
    public class EventProducer
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;

        public EventProducer(string connectionString, string queueName)
        {
            _client = new ServiceBusClient(connectionString);
            _sender = _client.CreateSender(queueName);
        }

        public async Task SendMessageAsync(string message)
        {
            var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(message));
            await _sender.SendMessageAsync(serviceBusMessage);
        }
    }
}
