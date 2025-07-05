using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_system.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public Customer(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public bool CanPay(decimal amount)
        {
            return Balance >= amount;
        }

    }
}
