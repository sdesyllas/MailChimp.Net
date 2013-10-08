using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Net.Api;
using MailChimp.Net.Api.Domain;
using MailChimp.Net.Settings;
using NUnit.Framework;

namespace MailChimp.Net.Tests
{
    [TestFixture]
    public class SectionTests
    {
        [Test]
        public void TestPing()
        {
            IMailChimpApiService mailChimpApiService = new MailChimpApiService(MailChimpServiceConfiguration.Settings.ApiKey);

            var response = mailChimpApiService.PingMailChimpServer();
            Console.WriteLine(response.ResponseJson);
            Assert.AreEqual(true, response.IsSuccesful);
        }

        [TestCase("spyros{0}@gmail.com", 5)]
        public void TestSubscribe(string emailPattern, int numberOfEmails)
        {
            IMailChimpApiService mailChimpApiService = new MailChimpApiService(MailChimpServiceConfiguration.Settings.ApiKey);
            for (int i = 0; i < numberOfEmails; i++)
            {
                var response = mailChimpApiService.Subscribe(String.Format(emailPattern, i), false);
                Console.WriteLine(response.ResponseJson);
                Assert.AreEqual(true, response.IsSuccesful);
            }
        }

        [TestCase("spyros_bluecoupon{0}@gmail.com", 5)]
        public void TestSubscribeWithGroupingsAndMergeVars(string emailPattern, int numberOfEmails)
        {
            IMailChimpApiService mailChimpApiService = new MailChimpApiService(MailChimpServiceConfiguration.Settings.ApiKey);
            for (int i = 0; i < numberOfEmails; i++)
            {
                var subscribeSources = new Grouping {Name = "Subscribe Source"};
                subscribeSources.Groups.Add("Site");

                var couponsGained = new Grouping {Name = "Coupons Gained"};
                couponsGained.Groups.Add("Coupon1");

                var interests = new Grouping {Name = "Interests"};
                interests.Groups.Add("Extreme Games");


                var fields = new Dictionary<string, string>
                    {
                        {"GENDER", "Male"},
                        {"DATEBORN", DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                        {"CITY", "Athens"},
                        {"COUNTRY", "Greece"}
                    };

                var response = mailChimpApiService.Subscribe(String.Format(emailPattern, i), new List<Grouping>() { subscribeSources, couponsGained, interests }, fields, false);
                Console.WriteLine(response.ResponseJson);
                Assert.AreEqual(true, response.IsSuccesful);
            }
        }


        [TestCase("spyros{0}@gmail.com", 5)]
        public void TestUnSubscribe(string emailPattern, int numberOfEmails)
        {
            IMailChimpApiService mailChimpApiService = new MailChimpApiService(MailChimpServiceConfiguration.Settings.ApiKey);
            for (int i = 0; i < numberOfEmails; i++)
            {
                var response = mailChimpApiService.Unsubscribe(String.Format(emailPattern, i));
                Console.WriteLine(response.ResponseJson);
                //Assert.AreEqual(true, response.IsSuccesful);
            }
        }
    }
}
