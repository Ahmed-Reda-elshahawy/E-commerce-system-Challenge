using E_commerce_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_system.Services
{
    public class ShipingService : IShipingService
    {
        public List<IShippable> Products { get; }
        public ShipingService(List<IShippable> products)
        {
            Products = products;
        }


        public string getName()
        {
            return "Standard Shipping Service";
        }

        public double getWeight()
        {
            double totalWeight = 0;
            foreach (var product in Products)
            {
                totalWeight += product.Weight;
            }
            return totalWeight;
        }

        public void ShipItems()
        {
            Console.WriteLine("Shipping the following items:");
            Console.WriteLine($"Shipping Service: {getName()}, total Weight: {getWeight()} kg");
        }
    }
}
