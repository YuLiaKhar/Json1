using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace Json2
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Logs/Products.json"; // чтобы работало нужно скопировать созданную в первой программе папку с файлом в новую программу 
            StreamReader srProductJson = new StreamReader(file);
            string productJsonReadToEnd = srProductJson.ReadToEnd();
            Console.WriteLine(productJsonReadToEnd);
            Product[] products = JsonSerializer.Deserialize<Product[]>(productJsonReadToEnd);

            int n = 0;
            double max = products[n].Max();
            string maxName = products[n].MaxName();

            for (int i = 0; i < 4; i++)
            {
                if (max < products[i + 1].Max())
                {
                    max = products[i + 1].Max();
                    maxName = products[i + 1].MaxName();
                }
            }
            Console.WriteLine("Самый дорогой товар: {0}. Его стоимость равна {1}.", maxName, max);

            Console.ReadKey();
        }
    }
    class Product
    {
        //[JsonPropertyName("Код товара")]
        public int Code { get; set; }
        //[JsonPropertyName("Наименование товара")]
        public string Name { get; set; }
        //[JsonPropertyName("Цена товара")]
        public double Price { get; set; }
        public Product(int code, string name, double price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
        public double Max()
        {
            return Price;
        }
        public string MaxName()
        {
            return Name;
        }
    }
}
