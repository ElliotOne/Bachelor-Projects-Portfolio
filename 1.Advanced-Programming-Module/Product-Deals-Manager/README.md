# Console Application: Product-Deals-Manager

## Overview

Welcome to the Product Deals Manager console application! This program allows you to manage products, customers, and deals efficiently.

## Classes

### Product

- **Attributes:**
  - `name` (string): The name of the product.
  - `price` (float): The price of the product.
  - `count` (int): The available quantity of the product.

### Customer

- **Attributes:**
  - `fullname` (string): The full name of the customer.
  - `ssid` (int): The Social Security ID of the customer.
  - `address` (string): The address of the customer.
  - `products` (List<Product>): The list of products associated with the customer.

### Deal

- **Attributes:**
  - `customerSsid` (int): The Social Security ID of the customer involved in the deal.
  - `product` (Product): The product associated with the deal.

## Main Functionality

- **Add New Product:**
  - Option 1 allows you to add a new product to the system.

- **Add New Customer:**
  - Option 2 enables you to add a new customer, including their personal information.

- **Add New Deal:**
  - Option 3 lets you create a new deal, connecting a customer and a product.

- **Show All Products List:**
  - Option 4 displays a list of all products in the system.

- **Show All Customers:**
  - Option 5 shows a list of all customers along with their details.

- **List of All Deals:**
  - Option 6 provides a list of all deals made.

- **Show a Customer All Deals:**
  - Option 7 allows you to view all deals associated with a specific customer.

- **Exit:**
  - Option -1 exits the program.

## How to Use

1. Run the application.
2. Choose an option from the menu by entering the corresponding number.
3. Follow the prompts to perform the desired operation.
4. Exit the application when you are done.

Feel free to explore and manage your product deals efficiently with this console application!
