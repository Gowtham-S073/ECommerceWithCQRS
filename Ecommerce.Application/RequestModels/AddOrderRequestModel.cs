using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.RequestModels
{
    public class AddOrderRequestModel: IRequest<string>
    {
        public Guid OrderID { get; set; } = new Guid();
        public Guid UserID { get; set; } = new Guid();
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
