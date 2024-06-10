using Ecommerce.Application.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Field
        private readonly IMediator _mediator;
        #endregion

        #region Parameterized Constructor
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region To Add the user details
        [HttpPost]  
        public async Task<IActionResult> AddUser([FromBody] AddNewUserModel request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        #endregion

        #region To login the user
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] AddNewUserModel request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        #endregion
    }
}
