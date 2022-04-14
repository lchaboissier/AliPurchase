using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliPurchase.Models
{
    class Login
    {
        //We need to create a sub class inside this class to access to the token according to the JSON response to /login route
        public class SuccessMessage
        {
            public string Token { get; set; }
        }

        //Here is the property
        public SuccessMessage Success { get; set; }

        public static String Connect(String email, String pwd)
        {
            String message;
            // Create an associative array with the email and the password
            Dictionary<String, String> userCredentials = new Dictionary<string, string>();
            userCredentials.Add("email", email);
            userCredentials.Add("password", pwd);

            // Call :login route to the API
            IRestResponse response = Api.Post("login", userCredentials);

            // Print the response content into the console
            Console.WriteLine(response.Content);

            // Deserialize the response content according to the Login class properties
            Login result = JsonConvert.DeserializeObject<Login>(response.Content);

            // Assign a message according to the response status code
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    message = "Success";
                    // Store the token
                    Api.Token = result.Success.Token;
                    // Print the token into the console
                    Console.WriteLine(result.Success.Token);
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    message = "You are not allowed ! Please try again !";
                    break;
                default:
                    message = "Oups ! There is a problem with your internet connection !";
                    break;
            }

            return message;
        }
    }
}
