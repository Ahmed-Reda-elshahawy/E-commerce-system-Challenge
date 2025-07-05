using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_system.Models
{
    class DigitalProduct : Product
    {
        public DigitalProduct(string name, decimal price, int quantity) : base(name, price, quantity)
        {
        }
    }
}
