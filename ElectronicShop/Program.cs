using ElectronicShop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace ElectronicShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1

            // List of products
            List<Product> products = new List<Product>
            {
                new Product("Gaming Laptop", "Computer", 12500m, new List<string> { "Gaming", "Laptop", "High Performance" }),
                new Product("Office Laptop", "Computer", 7500m, new List < string > { "Office", "Laptop", "Low Performance", "Work" }),
                new Product("Gaming Mus", "Tilbehør", 650m, new List < string > { "Gaming", "Mouse", "Comfortable Grip" }),
                new Product("Keyboard", "Tilbehør", 1100m, new List < string > { "Keyboard", "Mechanical Keys" }),
                new Product("4K Skærm", "Skærm", 4500m, new List < string > { "Gaming", "Screen", "High Definition", "4K" }),
                new Product("Gaming Headset", "Tilbehør", 1500m, new List < string > { "Gaming", "Headset", "Noise-canceling", "High-fidelity" }),
                new Product("27\" Gaming Skærm", "Skærm", 3500m, new List < string > { "Gaming", "Screen", "High Definition" }),
                new Product("USB-C Dock", "Tilbehør", 1800m, new List < string > { "Gaming", "Docker", "High Performance" }),
                new Product("MacBook Air", "Computer", 9500m, new List < string > { "Office", "Laptop", "School", "Work" }),
                new Product("Gaming PC", "Computer", 15000m, new List < string > { "Gaming", "PC", "High Performance" }),
                new Product("Webkamera", "Tilbehør", 850m, new List < string > { "Facetime", "Camera", "Webcam" }),
                new Product("32\" 4K Skærm", "Skærm", 5500m, new List < string > { "Gaming", "Screen", "High Definition" })
            };

            bool running = true;

            while (running)
            {
                Console.WriteLine("=== Electronic Shop LINQ ===");
                Console.WriteLine("1. Search and filter");
                Console.WriteLine("2. Select and transform");
                Console.WriteLine("3. Sort products");
                Console.WriteLine("4. Unique categories");
                Console.WriteLine("5. Check conditions");
                Console.WriteLine("6. Analyze products");
                Console.WriteLine("7. Group by category");
                Console.WriteLine("8. Pagination");
                Console.WriteLine("9. Tags");
                Console.WriteLine("10. Full shop analysis");
                Console.WriteLine("0. Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowFiltering(products);
                        break;

                    case "2":
                        ShowTransformations(products);
                        break;

                    case "3":
                        ShowSorting(products);
                        break;

                    case "4":
                        ShowUniqueCategories(products);
                        break;

                    case "5":
                        ShowConditions(products);
                        break;

                    case "6":
                        ShowAnalysis(products);
                        break;

                    case "7":
                        ShowGrouping(products);
                        break;

                    case "8":
                        ShowPagination(products);
                        break;

                    case "9":
                        ShowTags(products);
                        break;

                    case "10":
                        ShowFullAnalysis(products);
                        break;

                    case "0":
                        running = false;
                        break;
                }
            }
        }

        // Assignment 1 // Search and filter data
        static void ShowFiltering(List<Product> products)
        {
            // Using LINQ operators to get data

            // Get all computers
            var computers = products.Where(product => product.Category == "Computer");

            Console.WriteLine("\n=== Computers ===");
            foreach (Product product in computers)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // Get all products above 5000kr
            var expensiveProducts = products.Where(product => product.Price > 5000m);

            Console.WriteLine("\n=== Products above 5000 kr. ===");
            foreach (Product product in expensiveProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // Get all products between 1000kr and 5000kr
            var midRangeProducts = products.Where(product => product.Price >= 1000m && product.Price <= 5000m);

            Console.WriteLine("\n=== Products between 1000 and 5000 kr. ===");
            foreach (Product product in midRangeProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // Get all accessories above 1000kr
            var expensiveAccessories = products.Where(product => product.Category == "Tilbehør" && product.Price > 1000m);

            Console.WriteLine("\n=== Accessories above 1000 kr. ===");
            foreach (Product product in expensiveAccessories)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // Get all products with "Gaming" in the name
            var gamingProducts = products.Where(product => product.Name.Contains("Gaming"));

            Console.WriteLine("\n=== Gaming products ===");
            foreach (Product product in gamingProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            Console.WriteLine();
        }

        // Assignment 2 // Select and transform data
        static void ShowTransformations(List<Product> products)
        {
            // 2

            // Return only product names
            var productNames = products.Select(product => product.Name);

            Console.WriteLine("\n=== Product Names ===");
            foreach (string name in productNames)
            {
                Console.WriteLine(name);
            }

            // Return product name and price
            var productNameAndPrice = products.Select(product => new
            {
                product.Name,
                product.Price
            });

            Console.WriteLine("\n=== Product Names and Prices ===");
            foreach (var product in productNameAndPrice)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // Anonymous type with name, category and price
            var productInfo = products.Select(product => new
            {
                product.Name,
                product.Category,
                product.Price
            });

            Console.WriteLine("\n=== Product Information ===");
            foreach (var product in productInfo)
            {
                Console.WriteLine($"{product.Name} - {product.Category} - {product.Price} kr.");
            }

            // Transform each product into a formatted string
            var productText = products.Select(product => $"{product.Name} koster {product.Price} kr.");

            Console.WriteLine("\n=== Formatted Product Text ===");
            foreach (string text in productText)
            {
                Console.WriteLine(text);
            }

            Console.WriteLine();
        }

        // Assignment 3 // Sort data
        static void ShowSorting(List<Product> products)
        {
            // Sort by price - lowest to highest
            var priceAscending = products.OrderBy(product => product.Price);

            // Sort by price - highest to lowest
            var priceDescending = products.OrderByDescending(product => product.Price);

            // Sort by category
            var categorySorted = products.OrderBy(product => product.Category);

            // Sort by category, then by price
            var categoryThenPrice = products.OrderBy(product => product.Category).ThenBy(product => product.Price);

            // Sort by category, then by product name
            var categoryThenName = products.OrderBy(product => product.Category).ThenBy(product => product.Name);
        }

        // Assignment 4 // Remove duplicates
        static void ShowUniqueCategories(List<Product> products)
        {
            // 4

            // Get all unique categories
            var categories = products.Select(product => product.Category).Distinct();

            foreach (string category in categories)
            {
                Console.WriteLine(category);
            }

            // Count unique categories
            int categoryCount = products.Select(product => product.Category).Distinct().Count();

            Console.WriteLine($"Number of categories: {categoryCount}");
        }

        // Assignment 5 // Check conditions
        static void ShowConditions(List<Product> products)
        {
            // 5

            // Check if at least one product costs more than 10000kr
            bool productAbove10000 = products.Any(product => product.Price > 10000m);

            // Check if at least one product is in the "Skærm" category
            bool hasScreen = products.Any(product => product.Category == "Skærm");

            // Check if all products cost more than 500kr
            bool allAbove500 = products.All(product => product.Price > 500m);

            // Check if all computers cost more than 5000kr
            bool allComputersAbove5000 = products.Where(product => product.Category == "Computer").All(product => product.Price > 5000m);
        }

        // Assignment 6 // Analyze data
        static void ShowAnalysis(List<Product> products)
        {
            // 6

            // Total number of products
            int productCount = products.Count();

            // Total value of all products
            decimal totalValue = products.Sum(product => product.Price);

            // Average price of all products
            decimal averagePrice = products.Average(product => product.Price);

            // Cheapest product
            Product? cheapestProduct = products.MinBy(product => product.Price);

            // Most expensive product
            Product? mostExpensiveProduct = products.MaxBy(product => product.Price);

            // Number of products in the "Computer" category
            int computerCount = products.Count(product => product.Category == "Computer");

            // Average price of products in the "Tilbehør" category
            decimal accessoryAverage = products.Where(product => product.Category == "Tilbehør").Average(product => product.Price);
        }

        // Assignment 7 // Group and analyze data
        static void ShowGrouping(List<Product> products)
        {
            // 7
            Console.WriteLine("\n|| 7. Group with LINQ ||\n");

            // Group products by category
            var groupedProducts = products.GroupBy(product => product.Category);

            // Display and analyze each category
            foreach (var group in groupedProducts)
            {
                Console.WriteLine(group.Key);

                foreach (Product product in group)
                {
                    Console.WriteLine($"- {product.Name}");
                }

                Console.WriteLine($"Number of products: {group.Count()}");
                Console.WriteLine($"Average price: {group.Average(product => product.Price)} kr.");

                Product? mostExpensive = group.MaxBy(product => product.Price);
                Console.WriteLine($"Most expensive: {mostExpensive?.Name}");

                Console.WriteLine();
            }
        }

        // Assignment 8 // Limit and skip data
        static void ShowPagination(List<Product> products)
        {
            // 8
            Console.WriteLine("\n|| 8. Limit and skip data with LINQ ||\n");

            // Find the 3 most expensive products
            var threeMostExpensive = products.OrderByDescending(product => product.Price).Take(3);

            // Find the 5 cheapest products
            var fiveCheapest = products.OrderBy(product => product.Price).Take(5);

            // Sort all products by price descending
            var productsDescending = products.OrderByDescending(product => product.Price);

            // Keep products in positions 4-6
            var productsFourToSix = productsDescending.Skip(3).Take(3);

            // Pagination manually one page at the time

            // Page 1
            var page1 = products.Take(3);

            // Page 2
            var page2 = products.Skip(3).Take(3);

            // Page 3
            var page3 = products.Skip(6).Take(3);

            // Pagination dynamically calculated

            int pageSize = 3;
            int totalPages = (int)Math.Ceiling((double)products.Count() / pageSize);

            for (int pageNumber = 1; pageNumber <= totalPages; pageNumber++)
            {
                var page = products.Skip((pageNumber - 1) * pageSize).Take(pageSize);

                Console.WriteLine($"Page {pageNumber}");

                foreach (Product product in page)
                {
                    Console.WriteLine(product.Name);
                }
            }
        }

        // Assignment 9 // Work with collections inside collections
        static void ShowTags(List<Product> products)
        {
            // 9
            Console.WriteLine("\n|| 9. Work with collections ||\n");

            // Find all tags from products
            var allTags = products.SelectMany(product => product.Tags);

            // Find all unique tags
            var uniqueTags = products.SelectMany(product => product.Tags).Distinct();

            // Find all products that are tagged with user search
            Console.Write("Search for tag: ");
            string searchedTag = Console.ReadLine();

            var matchingProducts = products.Where(product => product.Tags.Contains(searchedTag));

            // Find how many unique tags exist
            int uniqueTagCount = products.SelectMany(product => product.Tags).Distinct().Count();
        }

        // Assignment 10 // Full analysis of ElectronicShop
        static void ShowFullAnalysis(List<Product> products)
        {
            Console.WriteLine("=== CATEGORY ANALYSIS ===");

            Console.WriteLine("=== TOP PRODUCTS ===");

            Console.WriteLine("=== PRODUCT FILTERING ===");

            Console.WriteLine("=== TAGS ===");
        }
    }
}
