# Product Management System

Product Management System is a simple C# console application that manages a list of digital and physical products, along with a list of customers. It includes features such as discount calculation, product categorization, stock tracking, and JSON file import/export. The application demonstrates basic object-oriented principles, interface usage, file serialization, and filtering logic.

## 🔧 Features

- Manage both **Digital** and **Physical** products
- Track product stock and trigger low-stock alerts
- Apply percentage discounts to products
- Save and load data from JSON files
- Sort and filter products by category or discount
- Sort customers by name
- Display formatted product and customer data in the console

## 📦 Technologies Used

- **C#** (.NET)
- **System.Text.Json** for JSON serialization
- Console Application architecture

## 📁 File Structure

- **Product.cs** – Base abstract class for all product types
- **DigitalProduct.cs** & **PhysicalProduct.cs** – Product types implementing **IDiscountable**
- **FileManager.cs** – Handles JSON import/export for products and customers
- **Program.cs** – Application entry point with UI logic and sorting/filtering functions
- **ProductDTO.cs** – Data Transfer Object for simplified JSON mapping
- **Customer.cs** – Immutable record type representing a customer
- **ProductCategory.cs** – Enum for product categories

## ▶️ How It Works

1. Loads product and customer data from JSON files.
2. Displays the list of all products and customers.
3. Applies discounts to all products.
4. Filters products by category (e.g., Toys).
5. Sorts customers by name.
6. Saves sorted data back to new JSON files.

## 📂 Example Output

```bash
All products before appling discount:
E-book - ₴120.76 (in stock: 197, 4.56 mb, file type: .fb2)
...
Discounts have been applied!

All products after appling discount:
E-book - ₴96.61 (in stock: 197, 4.56 mb, file type: .fb2)
...

Product "Cat's Toy Mouse" was purchased in the amount of 6.

Product "Cat's Toy Mouse" is almost sold out!

All products under Toys category:
Wooden Train Toy - ₴259.24 (in stock: 87, 5.54 kg weight, dimensions: 2x3.5x2)
Cat's Toy Mouse - ₴120.45 (in stock: 0, 0.15 kg weight, dimensions: 1x0.005x0.005)

All products under Toys category with discount:
Wooden Train Toy - ₴259.24 (in stock: 87, 5.54 kg weight, dimensions: 2x3.5x2)

All customers:
Dexter Kim - email: dxtrkm@gmail.com
...
