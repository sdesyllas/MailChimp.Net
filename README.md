==============
 MailChimp.NET
==============

.Net 4 wrapper Library for MailChimp newsletter API v2


1. Add the dlls to your project
2. Add the following lines in your configuration file
<pre>
&lt;configuration&gt;
  &lt;configSections&gt;
    &lt;section name="MailChimpServiceSettings" type="MailChimp.Net.Settings.MailChimpServiceConfiguration, MailChimp.Net.Settings" />
  &lt;/configSections&gt;
  &lt;MailChimpServiceSettings
    apiKey="testapikey-us7"
    subscriberListId="testlistid"
    serviceUrl="https://us7.api.mailchimp.com/2.0/"
    listsRelatedSection="lists"
    helperRelatedSection="helper"/&gt;
&lt;/configuration&gt;<pre>

3. Code example to subscribe a newsletter with the given groupings and merge vars
                
                IMailChimpApiService mailChimpApiService = new MailChimpApiService(MailChimpServiceConfiguration.Settings.ApiKey);
                
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

                var response = mailChimpApiService.Subscribe("test@domain.com", new List() { subscribeSources, couponsGained, interests }, fields, true);
