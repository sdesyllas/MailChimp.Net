using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    class Subscriber : MailChimpItem
    {
        [JsonProperty("email")]
        public Email Email { get; set; }
        
        [JsonProperty("double_optin")]
        public bool DoubleOptIn { get; set; }

        [JsonProperty("update_existing")]
        public bool UpdateExisting { get; set; }
        
        [JsonProperty("id")]
        public string ListId { get; set; }

        [JsonProperty("merge_vars")]
        public dynamic MergeVars { get; set; }
 
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
