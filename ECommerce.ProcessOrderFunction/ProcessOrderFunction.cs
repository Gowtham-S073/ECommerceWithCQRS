using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ECommerce.ProcessOrderFunction
{
    public class ProcessOrderFunction
    {
        private readonly IConfiguration _configuration;
        private readonly ServiceBusClient _serviceBusClient;

        public ProcessOrderFunction(IConfiguration configuration, ServiceBusClient serviceBusClient)
        {
            _configuration = configuration;
            _serviceBusClient = serviceBusClient;
        }

        [Function("ProcessOrderFunction")]
        public async Task RunAsync([ServiceBusTrigger("ecommercetopic", "sendorderdetails", Connection = "ServiceBusConnectionString")] ServiceBusReceivedMessage message)
        {
            // Parse the message
            var messageBody = JsonConvert.DeserializeObject<MessageBody>(message.Body.ToString());

            // Send the message to another Service Bus queue
            await SendMessageToQueueAsync(messageBody);
        }

        public async Task SendMessageToQueueAsync(MessageBody messageBody)
        {
            string queueName = "orderwithazure"; // Replace with your queue name

            ServiceBusSender sender = _serviceBusClient.CreateSender(queueName);

            string messageBodyJson = JsonConvert.SerializeObject(messageBody);
            ServiceBusMessage serviceBusMessage = new ServiceBusMessage(messageBodyJson);

            await sender.SendMessageAsync(serviceBusMessage);
        }
    }

    public class MessageBody
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
