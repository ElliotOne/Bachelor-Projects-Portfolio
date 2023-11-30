using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = new Customer[1000];
            Product[] products = new Product[1000];
            Deal[] deals = new Deal[1000];

            int custCounter = 0;
            int prodCounter = 0;
            int dealCounter = 0;

            Console.WriteLine("Welcome");
            while (true)
            {
                Console.WriteLine("Choose an options from the below : ");
                Console.WriteLine("1) Add new product");
                Console.WriteLine("2) Add new customer");
                Console.WriteLine("3) Add new deal");
                Console.WriteLine("4) Show all products list");
                Console.WriteLine("5) Show all customers");
                Console.WriteLine("6) List of all deals");
                Console.WriteLine("7) Show a customer all deals");
                Console.WriteLine("-1) Exit");
                Console.Write("Enter a number then press enter : ");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    products[prodCounter] = new Product();
                    Console.Write("Product name : ");
                    products[prodCounter].name = Console.ReadLine();
                    Console.Write("Product price : ");
                    products[prodCounter].price = float.Parse(Console.ReadLine());
                    Console.Write("Product count : ");
                    products[prodCounter].count = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"{products[prodCounter].name} added successfully.");
                    prodCounter++;
                }
                else if (input == 2)
                {
                    customers[custCounter] = new Customer();
                    Console.Write("Customer fullname : ");
                    customers[custCounter].fullname = Console.ReadLine();
                    Console.Write("Customer ssid : ");
                    customers[custCounter].ssid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Customer address : ");
                    customers[custCounter].address = Console.ReadLine();

                    Console.WriteLine($"{customers[custCounter].fullname} added successfully.");
                    custCounter++;
                }
                else if (input == 3)
                {
                    Console.Write("Ssid of customer : ");
                    int ssid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Product name : ");
                    string proname = Console.ReadLine();
                    Console.Write("Prodcut count : ");
                    int procount = Convert.ToInt32(Console.ReadLine());

                    int prodIndex = 0;
                    bool isFound = false;
                    for (int i = 0; i < products.Length; i++)
                    {
                        if (products[i].name == proname)
                        {
                            prodIndex = i;
                            isFound = true;
                            break;
                        }
                    }

                    if (isFound == false)
                    {
                        Console.WriteLine("Product not found.");
                    }
                    else
                    {
                        if (products[prodIndex].count >= procount)
                        {
                            for (int i = 0; i < customers.Length; i++)
                            {
                                if (customers[i].ssid == ssid)
                                {
                                    Product soldProduct = new Product();
                                    soldProduct.name = products[prodIndex].name;
                                    soldProduct.price = products[prodIndex].price;
                                    soldProduct.count = procount;

                                    customers[i].products = new List<Product>();
                                    customers[i].products.Add(soldProduct);
                                    products[prodIndex].count = products[prodIndex].count - procount;
                                    Console.WriteLine($"Customer {customers[i].ssid} has bought {procount} {products[prodIndex].name}.");

                                    //Save deal info
                                    deals[dealCounter] = new Deal();
                                    deals[dealCounter].customerSsid = ssid;

                                    deals[dealCounter].product = soldProduct;
                                    dealCounter++;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Not enough prodcuts of type {products[prodIndex].name} available.");
                        }
                    }
                }
                else if (input == 4)
                {
                    Console.WriteLine("List of all products : ");
                    foreach (var item in products)
                    {
                        if (item != null)
                        {
                            Console.WriteLine(item.name + "\t" + item.price + "$\t" + item.count);
                        }
                    }
                }
                else if (input == 5)
                {
                    Console.WriteLine("List of all customers : ");
                    foreach (var item in customers)
                    {
                        if (item != null)
                        {
                            Console.WriteLine(item.fullname + "\t" + item.ssid + "\t" + item.address);
                        }
                    }
                }
                else if (input == 6)
                {
                    Console.WriteLine("List of all deals : ");
                    foreach (var dl in deals)
                    {
                        if (dl != null)
                        {
                            Console.WriteLine(dl.customerSsid + "\t" + dl.product.name + "\t" + dl.product.count);
                        }
                    }
                }
                else if (input == 7)
                {
                    Console.Write("Customer fullname : ");
                    string fullname = Console.ReadLine();
                    int ssid = 0;
                    //get ssid from customers array
                    for (int i = 0; i < customers.Length; i++)
                    {
                        if (customers[i] != null)
                        {
                            if (fullname == customers[i].fullname)
                            {
                                ssid = customers[i].ssid;
                            }
                        }
                    }
                    List<Product> pros = new List<Product>();
                    for (int i = 0; i < deals.Length; i++)
                    {
                        if (deals[i] != null)
                        {
                            if (deals[i].customerSsid == ssid)
                            {
                                Product pr = deals[i].product;
                                pros.Add(pr);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    foreach (var item in pros)
                    {
                        Console.WriteLine(item.name + "\t" + item.count);
                    }
                }
                else if (input == -1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error : Wrong input , no option.");
                }
                Console.WriteLine("Press any key to continue the program ... ");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}