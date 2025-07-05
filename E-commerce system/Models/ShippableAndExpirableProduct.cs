using E_commerce_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_system.Models
{
    class ShippableAndExpirableProduct : Product, IShippable, IExpirable
    {
        public double Weight { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ShippableAndExpirableProduct(string name, decimal price, int quantity, double weight, DateTime expiryDate) : base(name, price, quantity)
        {
            Weight = weight;
            ExpiryDate = expiryDate;
        }
    }
}
