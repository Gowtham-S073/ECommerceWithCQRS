using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.RequestModels
{
    public class AddNewUserModel : IRequest<string>
    {
        public Guid UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] Password { get; set; } 
        public byte[] Hashkey { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
