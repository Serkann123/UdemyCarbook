using System.Net;

namespace UdemyCarbook.WebUI.Models
{
    public class ApiPostResult
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? RawBody { get; set; }
        public string? ReasonPhrase { get; set; }
    }
}
