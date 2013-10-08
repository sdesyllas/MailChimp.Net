﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Net.Api.Domain;
using MailChimp.Net.Settings;
using Newtonsoft.Json;
using log4net;

namespace MailChimp.Net.Api
{
    public class MailChimpApiService : IMailChimpApiService
    {
        private readonly ILog _log = LogManager.GetLogger("MailChimpApiService");

        public MailChimpApiService(string apiKey)
        {
            _apiKey = apiKey;
        }

        private readonly string _apiKey;

        /// <summary>
        /// https://us2.api.mailchimp.com/2.0/helper/ping
        /// </summary>
        /// <returns></returns>
        public ServiceResponse PingMailChimpServer()
        {
            ServiceResponse serviceResponse = new ServiceResponse();

            var urlTemplate = String.Format("{0}{1}/ping.json/", MailChimpServiceConfiguration.Settings.ServiceUrl,
                                            MailChimpServiceConfiguration.Settings.HelperRelatedSection);

            string pingJson = @"{""apikey"": """ + _apiKey + @"""}";
            try
            {
                var responseData = PostHelpers.PostJson(urlTemplate, pingJson);
                _log.DebugFormat("MailChimpService Call : {0}, response json : {1}", pingJson, responseData);
                serviceResponse.ResponseJson = responseData;
                serviceResponse.IsSuccesful = true;
            }
            catch (WebException exception)
            {
                using (Stream stream = exception.Response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    String responseString = reader.ReadToEnd();
                    serviceResponse.ResponseJson = responseString;
                    _log.Error(responseString);
                }
                _log.Error(exception);

                serviceResponse.IsSuccesful = false;
            }
            return serviceResponse;
        }

        public ServiceResponse Subscribe(string email, bool doubleOptIn)
        {
            var res = Subscribe(email, null, null, doubleOptIn);
            return res;
        }


        private ServiceResponse SubscribeWithMergeVars(string email, dynamic mergeVars, bool enableDoubleOptIn)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var urlTemplate = String.Format("{0}{1}/subscribe.json/", MailChimpServiceConfiguration.Settings.ServiceUrl,
                                            MailChimpServiceConfiguration.Settings.ListsRelatedSection);

            var subscriber = new Subscriber();
            subscriber.DoubleOptIn = enableDoubleOptIn;
            subscriber.ApiKey = _apiKey;
            subscriber.ListId = MailChimpServiceConfiguration.Settings.SubscriberListId;
            var emailObject = new Email { EmailValue = email };
            subscriber.Email = emailObject;
            subscriber.UpdateExisting = true;

            if (mergeVars != null)
            {
                subscriber.MergeVars = mergeVars;
            }
            try
            {
                var responseData = PostHelpers.PostJson(urlTemplate, subscriber.ToString());
                var deserializedData = JsonConvert.DeserializeObject<Email>(responseData);
                _log.DebugFormat("MailChimpService Call : {0}, response json : {1}", subscriber, deserializedData);
                serviceResponse.IsSuccesful = deserializedData.EmailValue != null && deserializedData.Euid != null &&
                       deserializedData.Leid != null;
                serviceResponse.ResponseJson = responseData;
            }
            catch (WebException exception)
            {
                using (Stream stream = exception.Response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    String responseString = reader.ReadToEnd();
                    serviceResponse.ResponseJson = responseString;
                    _log.Error(responseString);
                }
                _log.Error(exception);
                serviceResponse.IsSuccesful = false;
            }
            return serviceResponse;
        }

        public ServiceResponse Subscribe(string email, List<Grouping> groupings, Dictionary<string, string> fields, bool enableDoubleOptIn)
        {
            dynamic mergeVars = new Dictionary<string, Object>();
            mergeVars.Add("groupings", groupings);

            foreach (var nameValue in fields)
            {
                //Dynamically adding properties to an ExpandoObject
                //http://stackoverflow.com/questions/4938397/dynamically-adding-properties-to-an-expandoobject
                mergeVars.Add(nameValue.Key, nameValue.Value);
            }
            var response = this.SubscribeWithMergeVars(String.Format(email), mergeVars, enableDoubleOptIn);

            return response;
        }

        public ServiceResponse Unsubscribe(string email)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var urlTemplate = String.Format("{0}{1}/unsubscribe.json/", MailChimpServiceConfiguration.Settings.ServiceUrl,
                                            MailChimpServiceConfiguration.Settings.ListsRelatedSection);

            var subscriber = new Subscriber();

            subscriber.ApiKey = _apiKey;
            subscriber.ListId = MailChimpServiceConfiguration.Settings.SubscriberListId;
            var emailObject = new Email { EmailValue = email };
            subscriber.Email = emailObject;
            subscriber.UpdateExisting = true;
            try
            {
                var responseData = PostHelpers.PostJson(urlTemplate, subscriber.ToString());
                var deserializedData = JsonConvert.DeserializeObject<Email>(responseData);
                _log.DebugFormat("MailChimpService Call : {0}, response json : {1}", subscriber, deserializedData);
                serviceResponse.IsSuccesful = deserializedData.EmailValue != null && deserializedData.Euid != null &&
                       deserializedData.Leid != null;
                serviceResponse.ResponseJson = responseData;
            }
            catch (WebException exception)
            {
                using (Stream stream = exception.Response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    String responseString = reader.ReadToEnd();
                    serviceResponse.ResponseJson = responseString;
                    _log.Error(responseString);
                }
                _log.Error(exception);
                serviceResponse.IsSuccesful = false;
            }
            return serviceResponse;
        }
    }
}
