using Ecommerce.Application.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.RequestModels
{
    public class GetAllOrderRequestModel:IRequest<List<GetAllOrderResponseModel>>
    {
    }
}
