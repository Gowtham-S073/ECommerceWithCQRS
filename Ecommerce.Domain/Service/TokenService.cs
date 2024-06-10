using Ecommerce.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Service
{
    public class TokenService
    {
        #region Fields
        private readonly SymmetricSecurityKey _key;
        #endregion

        #region Parametrized Constructor
        public AddTokenServiceHandler(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        #endregion

        #region Generate Token
        public string GenerateToken(AddNewUserModel addNewUserModel)
        {
            string token = string.Empty;
            //User identity
            var claims = new List<Claim>
            {
                new Claim("UserID",(addNewUserModel.UserID).ToString()),
                new Claim(ClaimTypes.Email,addNewUserModel.Email),
                new Claim("PhoneNumber",addNewUserModel.PhoneNumber),
                new Claim(ClaimTypes.Name,addNewUserModel.FirstName)
            };
            //Signature algorithm
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            //Assembling the token details
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };
            //Using teh handler to generate the token
            var tokenHandler = new JwtSecurityTokenHandler();
            var myToken = tokenHandler.CreateToken(tokenDescription);
            token = tokenHandler.WriteToken(myToken);
            return token;
        }
        #endregion

    }
}
