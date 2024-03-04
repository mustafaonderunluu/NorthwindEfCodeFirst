using NorthwindEfCodeFirst.Contexts;
using NorthwindEfCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NorthwindEfCodeFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
           // One();
            //  Two();
            // Three();
            // Four();
            //  Five();
           // Listele();
            //BirdenFazlaListeleme();
            

            Console.ReadLine();
        }

        private static void BirdenFazlaListeleme()
        {
            using (var nortwindContext = new NortwindConstext())
            {

                var result = from c in nortwindContext.Customers
                             select new { c.City, c.CompanyName, c.ContactName };

                foreach (var customer in result)
                {

                    Console.WriteLine(customer);

                }



            }
        }

        private static void Listele()
        {
            using (var nortwindContext = new NortwindConstext())
            {

                IQueryable<Customer> result = from c in nortwindContext.Customers
                                              where c.City =="London" && c.Country =="UK"
                                              select c;

                foreach (var customer in result)
                {

                    Console.WriteLine(customer.ContactName);

                }



            }
        }

        private static void Five()
        {
            using (var nortwindContext = new NortwindConstext())  //Güncelleme 
            {
                Customer customer = nortwindContext.Customers.Find("Önder");
                customer.Country = "Turkey";
                nortwindContext.SaveChanges();
            }
        }

        private static void Four()
        {
            using (var nortwindContext = new NortwindConstext())
            {
                Order order = nortwindContext.Orders.Find(1);
                nortwindContext.Orders.Remove(order);

                nortwindContext.SaveChanges();

            }
        }

        private static void Two()
        {
            using (var nortwindContext = new NortwindConstext())
            {
                Customer customer = nortwindContext.Customers.Find("Önder");
                customer.Orders.Add(new Order { OrderID = 1, OrderDate = DateTime.Now, ShipCity = "Antalya", ShipCountry = "Türkiye" });

                nortwindContext.SaveChanges();
            }
        }

        private static void One()
        {
            using (var nortwindContext = new NortwindConstext())
            {
                foreach (var customer in nortwindContext.Customers)
                {
                    Console.WriteLine("Customer Name: {0} ", customer.ContactName);
                }

              
               
            }
        }

        private static void Three()
        {
            using (var nortwindContext = new NortwindConstext())
            {
                Customer newCustomer = new Customer
                {
                    CustomerId = "Önder",
                    City = "İstanbul",
                    CompanyName = "YazılımEvi.Com",
                    ContactName = "Önder Ünlü",
                    Country = "Türkiye"
                };

                nortwindContext.Customers.Add(newCustomer);
                nortwindContext.SaveChanges();
            }
        }
    }  

}

