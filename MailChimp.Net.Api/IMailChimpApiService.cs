using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Net.Api.Domain;

namespace MailChimp.Net.Api
{
    public interface IMailChimpApiService
    {
        ServiceResponse PingMailChimpServer();

        ServiceResponse Subscribe(string email);

        ServiceResponse Subscribe(string email, List<Grouping> groupings, Dictionary<string, string> field);

        ServiceResponse Unsubscribe(string email);
    }
}
