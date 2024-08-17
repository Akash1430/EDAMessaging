namespace EDA_Messaging
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connection = "xxxx";
            string queueName = "xxxx";

            //generate event - push to the queue
            EventProducer eventProducer = new EventProducer(connection,queueName);

            // consume event - retrieve from the queue
            EventConsumer eventConsumer = new EventConsumer(connection,queueName);
        }
    }
}
