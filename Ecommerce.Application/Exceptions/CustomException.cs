using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Exceptions
{
    public class CustomException : Exception
    { 
        public string ErrorCode { get; set; }
        public CustomException(string errorCode) : base(errorCode)
        {
            ErrorCode = errorCode;
        }

        private static string GetErrorCode(string errorCode)
        {
            Dictionary<string, string> exceptionMessages = new Dictionary<string, string>
        {
            { "NoId", "Id is not matched. Try Again" },
            { "CantEmpty", "This Entry cannot be null" },
            { "Invalid", "Invalid data in the request." },
            {"Exist","User already exist or invalid data." },
            {"Unhandled","Unhandled exception has occured" }
        };

            if (exceptionMessages.TryGetValue(errorCode, out string? message))
            {
                return message;
            }

            return "An unspecified error occurred.";
        }
    }
}
