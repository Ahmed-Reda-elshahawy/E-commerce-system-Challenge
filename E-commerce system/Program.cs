using E_commerce_system.Models;

namespace E_commerce_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product cheese = new ShippableAndExpirableProduct("Cheese", 5.99m, 10, 0.5, DateTime.Now.AddDays(30));
            Product tv = new ShippableProduct("TV", 499.99m, 5, 15.0);
            Product scratchCart = new DigitalProduct("Scratch Cart", 19.99m, 5);

            Customer ahmed = new Customer("Ahmed", 1000m);
            Cart cart = new Cart(ahmed);

            CartItem cheeseItem = new CartItem(cheese, 2);
            CartItem tvItem = new CartItem(tv, 1);
            CartItem scratchCartItem = new CartItem(scratchCart, 5);

            try
            {
                cart.Add(cheeseItem);
                cart.Add(tvItem);
                cart.Add(scratchCartItem);
                cart.Remove(scratchCartItem);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.Message}");
                Console.ResetColor();
            }

            cart.Checkout();

        }
    }
}
