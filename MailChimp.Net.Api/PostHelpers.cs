using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp.Net.Api
{
    class PostHelpers
    {
        public static string PostJson(string url, string data)
        {
            var bytes = Encoding.Default.GetBytes(data);

            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                var response = client.UploadData(url, "POST", bytes);

                return Encoding.Default.GetString(response);
            }
        }
    }
}
