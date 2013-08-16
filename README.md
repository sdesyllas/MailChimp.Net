==============
 MailChimp.NET
==============

.Net 4 wrapper Library for MailChimp newsletter API v2

Example use

                var subscribeSources = new Grouping {Name = "Subscribe Source"};
                subscribeSources.Groups.Add("Coupon");

                var couponsGained = new Grouping {Name = "Coupons Gained"};
                couponsGained.Groups.Add("WIN10");

                var interests = new Grouping {Name = "Interests"};
                interests.Groups.Add("Extreme Games");


                var fields = new Dictionary<string, string>
                    {
                        {"GENDER", "Male"},
                        {"DATEBORN", DateTime.Now.ToString(CultureInfo.InvariantCulture)},
                        {"CITY", "Athens"},
                        {"COUNTRY", "Greece"}
                    };

                var response = mailChimpApiService.Subscribe("testemail@domain.com", new List<Grouping>() { subscribeSources, couponsGained, interests }, fields);
