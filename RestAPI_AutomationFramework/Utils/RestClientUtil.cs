using Newtonsoft.Json;
using RestSharp;
using System.Configuration;
using System.Net;

namespace RestAPI_AutomationFramework.Utils
{
    public class RestClientUtil
    {
        static RestClient _RestClient;
        static RestRequest _RestRequest;

        public static RestClient RestClient
        {
            get
            {
                if (_RestClient == null)
                {
                    return new RestClient(ConfigurationManager.AppSettings["BaseUrl"].ToString());
                }
                else
                {
                    return _RestClient;
                }
            }
        }


        public static RestRequest CreateRequest(string resource, Method method, DataFormat dataFormat)
        {
            return new RestRequest(resource, method);
        }

        public static RestRequest CreateRequest(string resource)
        {
            return new RestRequest(resource);

        }
        public static T Post<T>(string resource, string payLoad, DataFormat dataFormat)
        {
            return JsonConvert.DeserializeObject<T>(
                RestClient.Execute(CreateRequest(resource, Method.Post, dataFormat)
                                    .AddBody(payLoad)).Content
                );
        }

        public static bool Delete(string resource, DataFormat dataFormat, HttpStatusCode httpStatusCode)
        {
            return RestClient.Execute(CreateRequest(resource, Method.Delete, dataFormat)).StatusCode.Equals(httpStatusCode);
        }

        public static T Update<T>(string resource, string payLoad, DataFormat dataFormat)
        {
            return JsonConvert.DeserializeObject<T>(
                RestClient.Execute(CreateRequest(resource, Method.Patch, dataFormat)
                                    .AddBody(payLoad)).Content
                );
        }

        public static T Get<T>(string resource)
        {
            return JsonConvert.DeserializeObject<T>(RestClient.Execute(CreateRequest(resource)).Content);
        }
    }
}
