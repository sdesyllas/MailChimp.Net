using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public class Grouping
    {
        public Grouping()
        {
            this.Groups = new List<string>();
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("groups")]
        public List<string> Groups { get; set; }
    }
}
