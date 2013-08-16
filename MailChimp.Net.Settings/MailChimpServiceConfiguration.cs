using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp.Net.Settings
{
    public class MailChimpServiceConfiguration : ConfigurationSection
    {
        // ReSharper disable InconsistentNaming
        private static readonly MailChimpServiceConfiguration _settings = ConfigurationManager.GetSection("MailChimpServiceSettings") as MailChimpServiceConfiguration;
        // ReSharper restore InconsistentNaming

        public static MailChimpServiceConfiguration Settings
        {
            get
            {
                return _settings;
            }
        }

        [ConfigurationProperty("apiKey", DefaultValue = "testkey")]
        public string ApiKey
        {
            get { return (string)this["apiKey"]; }
            set { this["apiKey"] = value; }
        }

        [ConfigurationProperty("subscriberListId", DefaultValue = "testkey")]
        public string SubscriberListId
        {
            get { return (string)this["subscriberListId"]; }
            set { this["subscriberListId"] = value; }
        }

        //https://us2.api.mailchimp.com/2.0
        [ConfigurationProperty("serviceUrl", DefaultValue = "https://us2.api.mailchimp.com/2.0")]
        public string ServiceUrl
        {
            get { return (string)this["serviceUrl"]; }
            set { this["serviceUrl"] = value; }
        }

        //lists
        [ConfigurationProperty("listsRelatedSection", DefaultValue = "/lists")]
        public string ListsRelatedSection
        {
            get { return (string)this["listsRelatedSection"]; }
            set { this["listsRelatedSection"] = value; }
        }

        //lists
        [ConfigurationProperty("helperRelatedSection", DefaultValue = "/helper")]
        public string HelperRelatedSection
        {
            get { return (string)this["helperRelatedSection"]; }
            set { this["helperRelatedSection"] = value; }
        }
    }
}
