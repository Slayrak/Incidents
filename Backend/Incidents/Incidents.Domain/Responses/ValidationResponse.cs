using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Incidents.Domain.Responces
{
    public class ValidationResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Errors { get; set; }
    }
}
