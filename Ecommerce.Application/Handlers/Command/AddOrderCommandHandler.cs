using AutoMapper;
using Azure.Messaging.ServiceBus;
using Ecommerce.Application.RequestModels;
using Ecommerce.Domain.Models.CoreModels;
using ECommerce.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using MediatR;
using Newtonsoft.Json;
using System.Text;


namespace Ecommerce.Application.Handlers.Command
{
    public class AddOrderCommandHandler: IRequestHandler<AddOrderRequestModel, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ServiceBusClient _serviceBusClient;
        private readonly string _serviceBusConnectionString;
        private readonly string _serviceBusTopic;

        public AddOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _serviceBusConnectionString = configuration["ConnectionStrings:ServiceBusConnectionString"];
            _serviceBusTopic = configuration["ServiceBusTopic"];
            _serviceBusClient = new ServiceBusClient(_serviceBusConnectionString);
        }

        public async Task<string> Handle(AddOrderRequestModel request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);

            // Send order to Service Bus Topic
            await using var sender = _serviceBusClient.CreateSender(_serviceBusTopic);
            var orderJson = JsonConvert.SerializeObject(order);
            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(orderJson));

            await sender.SendMessageAsync(message, cancellationToken);

            return "Order added successfully and sent to Service Bus";
        }

    }
}
