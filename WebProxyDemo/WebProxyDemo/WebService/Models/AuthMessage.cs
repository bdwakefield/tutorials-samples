using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class AuthMessage
    {
        public string Token { get; set; }

        public static AuthMessage ReturnAuthMessage()
        {
            return new AuthMessage { Token="Login Success!" };
        }
    }
}