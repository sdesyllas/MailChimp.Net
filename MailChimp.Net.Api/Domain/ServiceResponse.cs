using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp.Net.Api.Domain
{
    public class ServiceResponse
    {
        public bool IsSuccesful { get; set; }

        public string ResponseJson { get; set; }
    }
}
