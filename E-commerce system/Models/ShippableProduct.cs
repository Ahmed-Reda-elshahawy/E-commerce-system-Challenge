using E_commerce_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_system.Models
{
    class ShippableProduct : Product, IShippable
    {
        public double Weight { get; set; }
        public ShippableProduct(string name, decimal price, int quantity, double weight) : base(name, price, quantity)
        {
            Weight = weight;
        }
    }
}
