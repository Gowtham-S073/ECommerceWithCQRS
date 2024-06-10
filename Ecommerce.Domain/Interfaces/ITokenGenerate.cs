using Ecommerce.Domain.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(User user);
    }
}
