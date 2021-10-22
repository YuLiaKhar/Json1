using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace Json1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string file = "Logs/Products.json";
            if (!File.Exists(file))
            {
                File.Create(file);
            }
            Product[] array = new Product[5];
            Console.WriteLine("Введите код, наименование и цену первого товара:");
            array [0] = new Product (Convert.ToInt32(Console.ReadLine()), Convert.ToString(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Введите код, наименование и цену второго товара:");
            array [1] = new Product(Convert.ToInt32(Console.ReadLine()), Convert.ToString(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Введите код, наименование и цену третьего товара:");
            array [2] = new Product(Convert.ToInt32(Console.ReadLine()), Convert.ToString(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Введите код, наименование и цену четвертого товара:");
            array [3] = new Product(Convert.ToInt32(Console.ReadLine()), Convert.ToString(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            Console.WriteLine("Введите код, наименование и цену пятого товара:");
            array [4] = new Product(Convert.ToInt32(Console.ReadLine()), Convert.ToString(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(array, options);
            StreamWriter swproductjson = new StreamWriter(file); // на этой строке выдает ошибку при первом запуске, если файла "Logs/Products.json" изначально нет
            swproductjson.WriteLine(jsonString);                 // со второго запуска работает нормально
            swproductjson.Close();
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
    }
}
