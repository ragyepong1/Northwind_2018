﻿using NorthwindTraders.DAL;
using NorthwindTraders.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NorthwindTraders.BLL
{
    /// <summary>
    /// The SandboxController is a place to "try out" LINQ.
    /// </summary>
    [DataObject]
    public class SandboxController
    {
        // TODO: ) Discontinued products

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> DiscontinuedProducts()
        {
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Products
                              where data.Discontinued
                              select data;
                return results.ToList();
            }
        }

        // TODO: ) Understocked products (UnitsInStock < ReorderLevel)

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> UnderstockedProducts()
        {
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Products
                              where data.UnitsInStock < data.ReorderLevel
                              select data;
                return results.ToList();
            }
        }

        // TODO: ) Recommended product re-orders (UnitsInStock + UnitsOnOrder > ReorderLevel)

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> RecommendedReorders()
        {
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Products
                              where (data.UnitsInStock + data.UnitsOnOrder) < data.ReorderLevel
                              select data;
                return results.ToList();
            }
        }

        // TODO: ) Create a method called Clearance items that returns a list of all the products where the product is disconmtinued and we have items in stock

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> ClearanceItems()
        {
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Products
                              where data.UnitsInStock > 0 && data.Discontinued
                              select data;
                return results.ToList();
            }
        }

        // TODO: ) Shippers and the number of orders they have handled

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ShipperInfo> ShipperSummary()
        {
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Shippers
                              select new ShipperInfo()
                              {
                                  Company = data.CompanyName,
                                  OrdersToDate = data.Orders.Count()
                              };
                return results.ToList();
            }
        }

        public class ShipperInfo
        {
            public string Company { get; internal set; }
            public int OrdersToDate { get; internal set; }
        }

        // TODO: 1) Customer Order History
        //          (dates, ship-to, freight, total cost, with order detail summary and employee rep)

        public List<CustomerOrderHistory> ListAllCustomerOrders()
        {
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Orders
                              select new CustomerOrderHistory()
                              {
                                  Company = data.Customer.CompanyName,
                                  OrdersDate = data.OrderDate,
                                  FreightCharge = data.Freight,
                                  TotalCost = (from item in data.OrderDetails
                                               select item.Quantity * item.UnitPrice).Sum()
                                            
                              };
                return results.ToList();
            }
        }
        public class CustomerOrderHistory
        {
            public string Company { get; internal set; }
            public decimal? FreightCharge { get; internal set; }
            public DateTime? OrdersDate { get; internal set; }
            public decimal TotalCost { get; internal set; }
        }



        // TODO: 2) Employee Bio
        // TODO: 3) Product Catalogue (by Category)
        // TODO: 4) Suppliers and their Products (with category photo and category name)
        // TODO: 5) Most Popular products sold (qty), by year and month
        // TODO: 6) Sales Regions and their Sales Representatives
        // TODO: 7) Sales, ordered by date, including the order date, the time allowed to ship (in days), the actual time to ship (in days), and the customer name/city.
        // TODO: 8) Market Area information: A union query listing all the cities of suppliers and customers, with two columns, one for the city name and the other for whether it is a customer or supplier.
        // TODO: 9) Top 5 customers (by total sales amount)
        // TODO: 10) Top selling products (by total sales quantity)
        // TODO: 11) Customer Sales Profile, showing the customer name, the number of orders placed, the average order amount (in $), and the max/min order amounts ($)
        // TODO: ) Discontinued products, with the date of the last time they were ordered by a customer.
    }
}
