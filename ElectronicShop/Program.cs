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

            // Program loop
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
            Console.WriteLine("\n|| 1. Search and filter data with LINQ ||\n");

            // a. Get all computers
            var computers = products.Where(product => product.Category == "Computer");

            Console.WriteLine("\n=== Computers ===");
            foreach (Product product in computers)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // b. Get all products above 5000kr
            var expensiveProducts = products.Where(product => product.Price > 5000m);

            Console.WriteLine("\n=== Products above 5000 kr. ===");
            foreach (Product product in expensiveProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // c. Get all products between 1000kr and 5000kr
            var midRangeProducts = products.Where(product => product.Price >= 1000m && product.Price <= 5000m);

            Console.WriteLine("\n=== Products between 1000 and 5000 kr. ===");
            foreach (Product product in midRangeProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // d. Get all accessories above 1000kr
            var expensiveAccessories = products.Where(product => product.Category == "Tilbehør" && product.Price > 1000m);

            Console.WriteLine("\n=== Accessories above 1000 kr. ===");
            foreach (Product product in expensiveAccessories)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // e. Get all products with "Gaming" in the name
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
            Console.WriteLine("\n|| 2. Select and transform data with LINQ ||\n");

            // a. Return only product names
            var productNames = products.Select(product => product.Name);

            Console.WriteLine("\n=== Product Names ===");
            foreach (string name in productNames)
            {
                Console.WriteLine(name);
            }

            // b. Return product name and price
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

            // c. Anonymous type with name, category and price
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

            // d. Transform each product into a formatted string
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
            Console.WriteLine("\n|| 3. Sort data with LINQ ||\n");

            // a. Sort by price - lowest to highest
            var priceAscending = products.OrderBy(product => product.Price);

            Console.WriteLine("\n=== Price - Lowest to Highest ===");
            foreach (Product product in priceAscending)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // b. Sort by price - highest to lowest
            var priceDescending = products.OrderByDescending(product => product.Price);

            Console.WriteLine("\n=== Price - Highest to Lowest ===");
            foreach (Product product in priceDescending)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // c. Sort by category
            var categorySorted = products.OrderBy(product => product.Category);

            Console.WriteLine("\n=== Sorted by Category ===");
            foreach (Product product in categorySorted)
            {
                Console.WriteLine($"{product.Category} - {product.Name} - {product.Price} kr.");
            }

            // d. Sort by category, then by price
            var categoryThenPrice = products.OrderBy(product => product.Category).ThenBy(product => product.Price);

            Console.WriteLine("\n=== Category, then Price ===");
            foreach (Product product in categoryThenPrice)
            {
                Console.WriteLine($"{product.Category} - {product.Name} - {product.Price} kr.");
            }

            // e. Sort by category, then by product name
            var categoryThenName = products.OrderBy(product => product.Category).ThenBy(product => product.Name);

            Console.WriteLine("\n=== Category, then Product Name ===");
            foreach (Product product in categoryThenName)
            {
                Console.WriteLine($"{product.Category} - {product.Name} - {product.Price} kr.");
            }

            Console.WriteLine();
        }

        // Assignment 4 // Remove duplicates
        static void ShowUniqueCategories(List<Product> products)
        {
            Console.WriteLine("\n|| 4. Remove duplicates with LINQ ||\n");

            // Get all unique categories
            var categories = products.Select(product => product.Category).Distinct();

            Console.WriteLine("\n=== Unique Categories ===");
            foreach (string category in categories)
            {
                Console.WriteLine(category);
            }

            // Count unique categories
            int categoryCount = products.Select(product => product.Category).Distinct().Count();

            Console.WriteLine($"Number of categories: {categoryCount}");

            Console.WriteLine();
        }

        // Assignment 5 // Check conditions
        static void ShowConditions(List<Product> products)
        {
            Console.WriteLine("\n|| 5. Check conditions with LINQ ||\n");

            // a. Check if at least one product costs more than 10000kr
            bool productAbove10000 = products.Any(product => product.Price > 10000m);

            // b. Check if at least one product is in the "Skærm" category
            bool hasScreen = products.Any(product => product.Category == "Skærm");

            // c. Check if all products cost more than 500kr
            bool allAbove500 = products.All(product => product.Price > 500m);

            // d. Check if all computers cost more than 5000kr
            bool allComputersAbove5000 = products.Where(product => product.Category == "Computer").All(product => product.Price > 5000m);

            Console.WriteLine("\n=== Checking Conditions ===");
            Console.WriteLine($"At least one product costs more than 10000 kr.: {productAbove10000}");
            Console.WriteLine($"At least one product is a screen: {hasScreen}");
            Console.WriteLine($"All products cost more than 500 kr.: {allAbove500}");
            Console.WriteLine($"All computers cost more than 5000 kr.: {allComputersAbove5000}");

            Console.WriteLine();
        }

        // Assignment 6 // Analyze data
        static void ShowAnalysis(List<Product> products)
        {
            Console.WriteLine("\n|| 6. Analyze data with LINQ ||\n");

            // a. Total number of products
            int productCount = products.Count();

            // b. Total value of all products
            decimal totalValue = products.Sum(product => product.Price);

            // c. Average price of all products
            decimal averagePrice = products.Average(product => product.Price);

            // d. Cheapest product
            Product? cheapestProduct = products.MinBy(product => product.Price);

            // e. Most expensive product
            Product? mostExpensiveProduct = products.MaxBy(product => product.Price);

            // f. Number of products in the "Computer" category
            int computerCount = products.Count(product => product.Category == "Computer");

            // g. Average price of products in the "Tilbehør" category
            decimal accessoryAverage = products.Where(product => product.Category == "Tilbehør").Average(product => product.Price);

            Console.WriteLine("\n=== Product Analysis ===");
            Console.WriteLine($"Total number of products: {productCount}");
            Console.WriteLine($"Total value of all products: {totalValue} kr.");
            Console.WriteLine($"Average product price: {averagePrice:F2} kr.");

            if (cheapestProduct != null)
            {
                Console.WriteLine($"Cheapest product: {cheapestProduct.Name} - {cheapestProduct.Price} kr.");
            }

            if (mostExpensiveProduct != null)
            {
                Console.WriteLine($"Most expensive product: {mostExpensiveProduct.Name} - {mostExpensiveProduct.Price} kr.");
            }

            Console.WriteLine($"Number of computers: {computerCount}");
            Console.WriteLine($"Average accessory price: {accessoryAverage:F2} kr.");

            Console.WriteLine();
        }

        // Assignment 7 // Group and analyze data
        static void ShowGrouping(List<Product> products)
        {
            Console.WriteLine("\n|| 7. Group with LINQ ||\n");

            // a. Group products by category
            var groupedProducts = products.GroupBy(product => product.Category);

            // b. Display all products under their category
            foreach (var group in groupedProducts)
            {
                Console.WriteLine(group.Key);

                foreach (Product product in group)
                {
                    Console.WriteLine($"- {product.Name}");
                }

                // c. Count the number of products in each category
                Console.WriteLine($"Number of products: {group.Count()}");

                // d. Calculate the average price in each category
                Console.WriteLine($"Average price: {group.Average(product => product.Price)} kr.");


                // e. Find the most expensive product in each category
                Product? mostExpensive = group.MaxBy(product => product.Price);
                Console.WriteLine($"Most expensive: {mostExpensive?.Name}");

                Console.WriteLine();
            }
        }

        // Assignment 8 // Limit and skip data
        static void ShowPagination(List<Product> products)
        {
            Console.WriteLine("\n|| 8. Limit and skip data with LINQ ||\n");

            // a. Find the 3 most expensive products
            var threeMostExpensive = products.OrderByDescending(product => product.Price).Take(3);

            Console.WriteLine("=== 3 Most Expensive Products ===");
            foreach (Product product in threeMostExpensive)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // b. Find the 5 cheapest products
            var fiveCheapest = products.OrderBy(product => product.Price).Take(5);

            Console.WriteLine("\n=== 5 Cheapest Products ===");
            foreach (Product product in fiveCheapest)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }


            // c. Sort all products by price descending
            var productsDescending = products.OrderByDescending(product => product.Price);

            Console.WriteLine("\n=== Products by Descending Price ===");
            foreach (Product product in productsDescending)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }


            // d. Keep products in positions 4-6
            var productsFourToSix = productsDescending.Skip(3).Take(3);

            Console.WriteLine("\n=== Products in Positions 4-6 ===");
            foreach (Product product in productsFourToSix)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr.");
            }

            // e. Pagination manually one page at the time

            // Page 1
            var page1 = products.Take(3);

            // Page 2
            var page2 = products.Skip(3).Take(3);

            // Page 3
            var page3 = products.Skip(6).Take(3);

            Console.WriteLine("\n=== Page 1 ===");
            foreach (Product product in page1)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine("\n=== Page 2 ===");
            foreach (Product product in page2)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine("\n=== Page 3 ===");
            foreach (Product product in page3)
            {
                Console.WriteLine(product.Name);
            }
        }

        // Assignment 9 // Work with collections inside collections
        static void ShowTags(List<Product> products)
        {
            Console.WriteLine("\n|| 9. Work with collections ||\n");

            // a. Find all tags from products
            var allTags = products.SelectMany(product => product.Tags);

            Console.WriteLine("=== All Tags ===");
            foreach (string tag in allTags)
            {
                Console.WriteLine(tag);
            }

            // b. Find all unique tags
            var uniqueTags = products.SelectMany(product => product.Tags).Distinct();

            Console.WriteLine("\n=== Unique Tags ===");
            foreach (string tag in uniqueTags)
            {
                Console.WriteLine(tag);
            }

            // c. Find all products that are tagged with user search
            Console.Write("Search for tag: ");
            string searchedTag = Console.ReadLine();

            var matchingProducts = products.Where(product => product.Tags.Contains(searchedTag));

            Console.WriteLine($"\n=== Products with tag: {searchedTag} ===");
            foreach (Product product in matchingProducts)
            {
                Console.WriteLine(product.Name);
            }

            // d. Find how many unique tags exist
            int uniqueTagCount = products.SelectMany(product => product.Tags).Distinct().Count();

            Console.WriteLine($"\nNumber of unique tags: {uniqueTagCount}");

            Console.WriteLine();
        }

        // I seem to have forgotten about 10, but I'm limited on time, sorry for it being blank!

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
