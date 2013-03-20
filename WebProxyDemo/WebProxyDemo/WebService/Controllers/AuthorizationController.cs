using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class AuthorizationController : ApiController
    {
        public HttpResponseMessage Get(string username)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AuthMessage.ReturnAuthMessage());
        }
    }
}
