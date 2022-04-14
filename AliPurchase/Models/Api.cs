using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace AliPurchase.Models
{
    class Api
    {
        public static String Token { get; set; }

        private static string _url = Properties.Resources.API_URL + Properties.Resources.API_VERSION + "/";
        public static IRestResponse Post(String route, Dictionary<String, String> fields = null)
        {
            // The HTTP instance object where to send the request
            RestClient clientApi = new RestClient(Api._url);

            // Prepare the request
            RestRequest request = new RestRequest(Method.POST);
            request.Resource = route;
            request.AddJsonBody(fields);

            // Send the HTTP request and return the response
            return clientApi.Execute(request);
        }

        public static IRestResponse GetWithToken(String route, Dictionary<String, String> fields = null)
        {
            // The HTTP instance object where to send the request
            RestClient clientApi = new RestClient(Api._url);

            // Prepare the request
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = route;
            request.AddHeader("Authorization", "Bearer " + Token);
            request.AddHeader("Accept", "application/json");

            // Don't include the fields if not necessary, else the request failed !
            if (null != fields)
            {
                foreach (KeyValuePair<String, String> field in fields)
                {
                    request.AddUrlSegment(field.Key, field.Value);
                }
            }
            // Send the HTTP request and return the response
            return clientApi.Execute(request);
        }
    }
}
