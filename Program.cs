using System.Net.WebSockets;
using System.Runtime.CompilerServices;

namespace Linq_home
{
    internal class Program
    {
        class Product
        {
            public string Name { get; set; }
            public int Year { get; set; }
            public string Country { get; set; }
            public string Category { get; set; }
            public int Price { get; set; }
            public override string ToString()
            {
                return $"Product name: {Name,-20} Category: {Category,-15} Country: {Country,-15} Year: {Year} Price: {Price}";
            }
        }

        static void ProdAmountByCountry(string country, params Product[] products)
        {
            var list = from i in products where i.Country == country select i;
            Console.WriteLine(list.Count());
            Console.WriteLine();
        }
        static void MinMaxPriceProdInCategory(string category, params Product[] products)
        {
            var list = from i in products where i.Category == category select i;
            int max = list.Select(i => i.Price).Max();
            int min = list.Select(i => i.Price).Min();

            var resmax = from i in list where i.Price == max select i;
            var resmin = from i in list where i.Price == min select i;
            Console.WriteLine("Max: " + string.Join("",resmax));
            Console.WriteLine("Min: " + string.Join("", resmin));
            Console.WriteLine();
        }

        static void NotUkrainianProdCategory(params Product[] products)
        {
            var list = from i in products where i.Country == "Ukraine" select i.Category;
            var notlist = from i in products where i.Country != "Ukraine" select i.Category;
            var res = notlist.Except(list);
            Console.WriteLine(string.Join("\n", res));
            Console.WriteLine();

        }

        static void CountProdInCategory(params Product[] products)
        {
            var list = products.GroupBy(i => i.Category).OrderBy(gr => gr.Count());
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key} : {item.Count()}");
            }
            Console.WriteLine();

        }

        static void GroupCategorySortByYear(params Product[] products)
        {
            var list = products.OrderBy(i => i.Year).GroupBy(i => i.Category);
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key} : ");
                foreach (var i in item)
                {
                    Console.WriteLine("\t"+i);
                }
            }
            Console.WriteLine();

        }
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product { Name = "Laptop", Year = 2022, Country = "USA", Category = "Electronics", Price = 1200 },
                new Product { Name = "Coffee Maker", Year = 2021, Country = "Germany", Category = "Appliances", Price = 90 },
                new Product { Name = "Running Shoes", Year = 2022, Country = "Vietnam", Category = "Apparel", Price = 60 },
                new Product { Name = "Smartphone", Year = 2022, Country = "South Korea", Category = "Electronics", Price = 800 },
                new Product { Name = "Toaster", Year = 2020, Country = "China", Category = "Appliances", Price = 40 },
                new Product { Name = "Desk Chair", Year = 2021, Country = "Sweden", Category = "Furniture", Price = 150 },
                new Product { Name = "Camera", Year = 2021, Country = "Japan", Category = "Electronics", Price = 500 },
                new Product { Name = "Cookware Set", Year = 2020, Country = "Italy", Category = "Kitchenware", Price = 120 },
                new Product { Name = "Winter Jacket", Year = 2022, Country = "Canada", Category = "Apparel", Price = 100 },
                new Product { Name = "Fitness Tracker", Year = 2022, Country = "USA", Category = "Electronics", Price = 70 },

                new Product { Name = "Office Chair", Year = 2021, Country = "Ukraine", Category = "Furniture", Price = 130 },
                new Product { Name = "DSLR Camera", Year = 2021, Country = "Ukraine", Category = "Electronics", Price = 480 },
                new Product { Name = "Cookware Set", Year = 2020, Country = "Ukraine", Category = "Kitchenware", Price = 110 },
                new Product { Name = "Activity Tracker", Year = 2022, Country = "Ukraine", Category = "Electronics", Price = 60 },
            };




            //1
            var query = from i in products where i.Year == 2022 orderby i.Price descending select i;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //2
            ProdAmountByCountry("USA", products);

            //3
            MinMaxPriceProdInCategory("Electronics", products);

            //4
            NotUkrainianProdCategory(products);
            //5
            CountProdInCategory(products);

            //6
            GroupCategorySortByYear(products);
        }
    }
}