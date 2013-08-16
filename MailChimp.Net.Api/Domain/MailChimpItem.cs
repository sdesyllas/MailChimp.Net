using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    class MailChimpItem
    {
        [JsonProperty("apikey")]
        public string ApiKey { get; set; }
    }
}
