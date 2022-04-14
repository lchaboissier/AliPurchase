using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliPurchase.Models
{
    class Product
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal VATrate{ get; set; }
        public int AlertQuantity { get; set; }
        public int OrderQuantity { get; set; }
        public string Category_id { get; set; } // Bug in the JSON, should be an int !!
        public bool Active { get; set; }
    }
}
