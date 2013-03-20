using System;
using System.Net;
using System.Web.UI;

namespace WebApplication
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string CallServer()
        {
            var response = RequestHelper.Get("http://localhost:1059/api/Authorization?username=bwakefield", "");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.ReturnValue;
            }

            return "Request failed! " + response.StatusCode;
        }
    }
}