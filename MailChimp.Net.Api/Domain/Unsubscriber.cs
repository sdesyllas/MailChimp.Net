using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    class Unsubscriber : MailChimpItem
    {
        [JsonProperty("email")]
        public Email Email { get; set; }

        [JsonProperty("delete_member")]
        public bool DeleteMember { get; set; }

        [JsonProperty("send_goodbye")]
        public bool SendGoodbye { get; set; }

        [JsonProperty("send_notify")]
        public bool SendNotify { get; set; }
     
        [JsonProperty("id")]
        public string ListId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
