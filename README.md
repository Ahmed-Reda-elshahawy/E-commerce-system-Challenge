# 🛒 E-Commerce Shopping Cart System
This project is a console-based e-commerce shopping cart system built using object-oriented principles and clean code practices. It models the fundamental components of an online shopping platform including customers, products (digital, shippable, and expirable), and a shipping service.
---

### 📌 Features
- Add and remove products from the cart
- Handle different product types:
  - DigitalProduct
  - ShippableProduct
  - ExpirableProduct
  - ShippableAndExpirableProduct
- Calculate subtotal, shipping fees, and total paid amount
- Validate customer balance before checkout
- Ship physical products using a shipping service
- Interfaces used to define extensible contracts (e.g., IShippable, IExpirable, IShippingService)
---

### ✅ Design Highlights
- Interface Segregation: Products implement only the interfaces relevant to them (IShippable, IExpirable)
- Dependency Inversion: ShippingService depends on abstractions (IShippable)
- Encapsulation & Modularity: Each class has a focused responsibility
- Extendable: Easily add new types of products or services
---

### UML Diagram
![image](https://github.com/user-attachments/assets/072ec8d6-5355-48bc-9b1d-24fd4bf3cc54)

### 📂 Project Structure
- Models/
  - Cart.cs
  - CartItem.cs
  - Customer.cs
  - Product.cs (abstract)
  - DigitalProduct.cs
  - ShippableProduct.cs
  - ExpirableProduct.cs
  - ShippableAndExpirableProduct.cs
- Interfaces/
  - IShippable.cs
  - IExpirable.cs
  - IShippingService.cs
- Services/
  - ShippingService.cs
- Program.cs
---

### 🚀 Getting Started
1. Clone the repository
2. Open in Visual Studio / VS Code
3. Run the console app and test different product scenarios
   
