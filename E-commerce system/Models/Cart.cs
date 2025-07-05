using E_commerce_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_system.Models
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();
        private readonly Customer customer;
        private bool hasErrors = false;
        public Cart(Customer customer)
        {
            this.customer = customer;
        }

        public void Add(CartItem item)
        {
            if (item.Quantity > item.Product.Quantity)
            {
                hasErrors = true;
                throw new Exception($"The product {item.Product.Name} is out of stock or insufficient quantity available.");
            }
            else if(item.Product is IExpirable expirable && expirable.ExpiryDate < DateTime.Now)
            {
                hasErrors = true;
                throw new Exception($"The product {item.Product.Name} is expired and cannot be purchased.");
            }
            items.Add(item);
        }

        public void Remove(CartItem item)
        {
            if (!items.Contains(item))
            {
                hasErrors = true;
                throw new Exception($"The product {item.Product.Name} is not in the cart.");
            }
            items.Remove(item);
        }

        public List<CartItem> GetItems()
        {
            return items;
        }

        public decimal GetSubtotal()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.Product.Price * item.Quantity;
            }
            return total;
        }

        public decimal GetShippingFees()
        {
            double totalWeight = items.Where(item => item.Product is IShippable)
                .Sum(item => (item.Product as IShippable)!.Weight * item.Quantity);
            return (decimal)totalWeight * 2;
        }

        public decimal GetPaidAmount()
        {
            return GetSubtotal() + GetShippingFees();
        }

        public void Checkout()
        {
            if(hasErrors)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There were errors in your cart. Please fix them before checking out.");
                Console.ResetColor();
                return;
            }
            else if (items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your cart is empty. Please add items before checking out.");
                Console.ResetColor();
                return;
            }
            else if (!customer.CanPay(GetPaidAmount()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have enough balance to complete the purchase.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("** Shipment notice **");
            double totalWeight = 0;
            foreach (var item in items)
            {
                if (item.Product is IShippable shippable)
                {
                    Console.WriteLine($"Shipping {item.Quantity}X {item.Product.Name} with weight {shippable.Weight * item.Quantity} kg.");
                    totalWeight += shippable.Weight * item.Quantity;
                }
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Total package weight: {totalWeight}kg");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("** Checkout receipt **");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Quantity}X {item.Product.Name} \t Price: {item.Product.Price * item.Quantity}");
                item.Product.Quantity -= item.Quantity;
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Subtotal: {GetSubtotal()}");
            Console.WriteLine($"Shipping Fees: {GetShippingFees()}");
            Console.WriteLine($"Total Amount: {GetPaidAmount()}");
            Console.WriteLine("Thank you for your purchase!");
            Console.ResetColor();

            customer.Balance -= GetPaidAmount();

            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Notification: Your balance has been updated to {customer.Balance:C}");
            Console.ResetColor();
            Console.WriteLine("==============================");
            items.Clear();
        }
    }
}
