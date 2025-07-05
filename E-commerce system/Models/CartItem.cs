using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_system.Models
{
    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; set; }
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

    }
}
