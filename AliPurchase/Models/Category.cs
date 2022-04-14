using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliPurchase.Models
{
    class Category
    {
        // Properties and Getters/Setters
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Parent_id { get; set; }
        public int CountChildren { get; set; }
        public int CountProducts { get; set; }
        public List<Category> Children { get; set; } // Array of sub-categories
        public List<Product> Products { get; set; } // Array of products of the category if exist
        // Construtor

        // Static methods for managing one or more records
        public static List<Category> All()
        {
            // Call the secure HTTP GET request
            IRestResponse response = Api.GetWithToken("category");

            // For debug
            Console.WriteLine("Category-All()");
            Console.WriteLine(response.Content);

            // Create a array of objects instances of the class using the JSON response
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(response.Content);

            return categories;

        }
        // Object methods for managing a object instance of this class
        public static Category Find(int IdCategory)
        {
            // Call the secure HTTP GET request with an id parameter
            IRestResponse response = Api.GetWithToken("category/{id}", new Dictionary<string, string>() { { "id", IdCategory.ToString() } });

            // For debug
            Console.WriteLine("Category-Find({0})", IdCategory);
            Console.WriteLine(response.Content);

            // Create a object instance of the class using the JSON response
            Category category = JsonConvert.DeserializeObject<Category>(response.Content);

            return category;
        }

    }
}
