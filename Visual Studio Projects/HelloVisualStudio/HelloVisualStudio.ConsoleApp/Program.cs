using System;
using System.Collections.Generic;
using System.Numerics;

namespace HelloVisualStudio.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // have a list of products and dispaly them to the user
            // customizable display

            // List<Product> products = new List<Product>();
            /*
            Product p = new Product("", "", 4, 1);

            discount(p);

            Console.WriteLine(p.Price);

            string word = "meme";
            modifystring(ref word);
            Console.WriteLine(word);

            BigInteger n = new BigInteger(9999999999999999999);

            for (int i = 0; i < 10; i++)
            {
                n *= n;
            }

            Console.WriteLine(n); */

        }
        static void discount(Product p)
        {
            p.Price *= 0.5;
        }
        static void modifystring(ref string s)
        {
            s = s + "lord";
        }
        static List<Product> GetProducts()
        {
            return null;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    class Writer
    {
        public static void FormatAndDisplay(List<Product> catalog)
        {
            foreach (var x in catalog)
            {
                Console.WriteLine(x.Id);
            }
        }
    }
}
