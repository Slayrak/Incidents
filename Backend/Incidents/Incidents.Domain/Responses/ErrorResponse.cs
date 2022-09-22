using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Incidents.Domain.Responces
{
    public class ErrorResponce
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }
}
