using AutoMapper;
using Ecommerce.Application.RequestModels;
using Ecommerce.Application.ResponseModels;
using Ecommerce.Domain.Models.CoreModels;
using ECommerce.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.Query
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderRequestModel, List<GetAllOrderResponseModel>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetAllOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        //Write a method to get all orders
        public async Task<List<GetAllOrderResponseModel>> Handle(GetAllOrderRequestModel req, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrders();
            var orderResponse = _mapper.Map<List<GetAllOrderResponseModel>>(orders);
            return orderResponse;
        }
    }
}
