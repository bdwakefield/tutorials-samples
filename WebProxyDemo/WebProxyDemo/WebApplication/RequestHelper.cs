using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace WebApplication
{
    public class RequestConfig
    {
        public string URI { get; set; }
        public HttpMethod Method { get; set; }
        public string ContentType { get; set; }
        public string Body { get; set; }
    }

    public class RequestResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ReturnValue { get; set; }
    }

    public static class RequestHelper
    {
        public static RequestResponse Get(string uri, string body)
        {
            var config = new RequestConfig { URI = uri, Method = HttpMethod.Get, ContentType = "text/json", Body = body };
            return MakeRequest(config);
        }

        private static RequestResponse MakeRequest(RequestConfig config)
        {
            var req = (HttpWebRequest)WebRequest.Create(config.URI);
            req.Method = config.Method.Method;
            req.ContentType = config.ContentType;

            if (config.Method.Method == HttpMethod.Post.Method && config.Body != null)
            {
                var stOut = new StreamWriter(req.GetRequestStream());
                stOut.Write(config.Body);
                stOut.Close();
            }

            var returnVal = new RequestResponse();
            try
            {
                var webResponse = (HttpWebResponse)req.GetResponse();
                returnVal.StatusCode = webResponse.StatusCode;
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = req.GetResponse().GetResponseStream();

                    if (responseStream != null)
                    {
                        var reader = new StreamReader(responseStream);
                        returnVal.ReturnValue = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                returnVal.ReturnValue = ex.Message;
                returnVal.StatusCode = HttpStatusCode.NotFound;
            }

            return returnVal;
        }
    }
}