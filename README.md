==============
 MailChimp.NET
==============

.Net 4 wrapper Library for MailChimp newsletter API v2


1. Add the dlls to your project
2. Add the following links in your configuration file


<configuration>
  <configSections>
    <section name="MailChimpServiceSettings" type="MailChimp.Net.Settings.MailChimpServiceConfiguration, MailChimp.Net.Settings" />
  </configSections>
  <MailChimpServiceSettings
    apiKey="testapikey-us7"
    subscriberListId="testlistid"
    serviceUrl="https://us7.api.mailchimp.com/2.0/"
    listsRelatedSection="lists"
    helperRelatedSection="helper"/>
</configuration>

3. Code example to subscribe a newsletter with the given groupings and merge vars

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

                var response = mailChimpApiService.Subscribe(String.Format(emailPattern, i), new List<Grouping>() { subscribeSources, couponsGained, interests }, fields);
