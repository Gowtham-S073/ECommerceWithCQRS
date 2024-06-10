using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.ResponseModels
{
    public class GetAllOrderResponseModel
    {
        public Guid OrderID { get; set; } 
        public Guid UserID { get; set; } 
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
