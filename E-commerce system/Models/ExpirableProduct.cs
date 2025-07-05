using E_commerce_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_system.Models
{
    class ExpirableProduct : Product, IExpirable
    {
        public DateTime ExpiryDate { get; set; }
        public ExpirableProduct(string name, decimal price, int quantity, DateTime expiryDate)
            : base(name, price, quantity)
        {
            ExpiryDate = expiryDate;
        }
    }
}
