using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public List<string> Tags { get; set; }

        public Product(string name, string category, decimal price, List<string> tags)
        {
            Name = name;
            Category = category;
            Price = price;
            Tags = tags;
        }
    }
}
