using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    /// <summary>
    /// "email":{"email": "example email", "euid": "example euid", "leid": "example leid"}
    /// </summary>
    public class Email
    {
        [JsonProperty("email")]
        public string EmailValue { get; set; }

        [JsonProperty("euid")]
        public string Euid { get; set; }
        
        [JsonProperty("leid")]
        public string Leid { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
