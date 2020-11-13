using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;

namespace HelloVisualStudio.ConsoleApp
{
    public class Product
    {
        // product id
        public string Id { get; }
        // name
        public string Name { get; }
        // price
        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can't be lower than 0");
                }
                _price = value;
            }
        }
        // quantity
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity can't be less than zero");
                }
                _quantity = value;
            }
        }
        // constructor
        public Product(string id, string name, double price, int quantity)
        {
            Id = id; Name = name; Price = price; Quantity = quantity;
        }
        public void AddInventory(int count) { Quantity += count; }
    }
}
