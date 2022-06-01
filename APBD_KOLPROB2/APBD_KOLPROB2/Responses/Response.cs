using System.Net;

namespace APBD_KOLPROB2.Responses
{
    public class Response
    {
        public string Message { get; set; }   
        public HttpStatusCode StatusCode { get; set; }
    }
}
