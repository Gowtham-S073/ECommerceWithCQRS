using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models.CoreModels
{
    public  class Order
    {
        public Guid OrderID { get; set; }= new Guid();
        public Guid UserID { get; set; } = new Guid();
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

