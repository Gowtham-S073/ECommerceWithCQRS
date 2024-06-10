using Ecommerce.Application.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Field
        private readonly IMediator _mediator;
        #endregion

        #region Parameterized Constructor
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion


        #region To Add the order details
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequestModel request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        #endregion


        #region To get all orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var request = new GetAllOrderRequestModel();
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        #endregion

    }
}
