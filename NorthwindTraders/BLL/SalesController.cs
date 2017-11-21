﻿using NorthwindTraders.DAL;
using NorthwindTraders.Entities.DTOs;
using NorthwindTraders.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.BLL
{
    [DataObject]
    public class SalesController
    {
        #region Methods for DataBound Controls
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<KeyValueOption> ListCustomerNames()
        {
            using (var context = new NorthwindContext())
            {
                var names = from data in context.Customers
                            orderby data.CompanyName
                            select new KeyValueOption
                            {
                                Key = data.CustomerID.ToString(),
                                Text = data.CompanyName
                            };
                return names.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<KeyValueOption> GetOrderHistoryFilters()
        {
            var results = new List<KeyValueOption>();
            results.Add(new KeyValueOption { Key = "open", Text = "Open" });
            results.Add(new KeyValueOption { Key = "shipped", Text = "Shipped" });
            return results.ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<KeyValueOption> GetProducts()
        {
            using (var context = new NorthwindContext())
            {
                var results = from data in context.Products
                              select new KeyValueOption
                              {
                                  Text = data.ProductName,
                                  Key = data.ProductID.ToString()
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<CustomerOrder> GetOrdersByCustomer(string customerId, string filter)
        {
            if (!"open".Equals(filter.ToLower()) && !"shipped".Equals(filter.ToLower()))
                throw new ArgumentException("Filter values are required", nameof(filter));
            using (var context = new NorthwindContext())
            {
                var shipped = "shipped".Equals(filter.ToLower());

                var results = from data in context.Orders
                              where data.CustomerID == customerId
                                 && data.ShippedDate.HasValue == shipped
                              select new CustomerOrder
                              {
                                  OrderId = data.OrderID,
                                  Employee = data.Employee.FirstName + " " + data.Employee.LastName,
                                  OrderDate = data.OrderDate,
                                  RequiredDate = data.RequiredDate,
                                  ShippedDate = data.ShippedDate,
                                  Freight = data.Freight,
                                  Shipper = data.Shipper.CompanyName,
                                  OrderTotal = data.OrderDetails.Sum(x => x.Quantity * x.UnitPrice)
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<string> ListCountries()
        {
            using (var context = new NorthwindContext())
            {
                var eCountries = context.Employees.Select(x => x.Country);
                var cCountries = context.Customers.Select(x => x.Country);
                var result = eCountries.Union(cCountries).Distinct().ToList();
                result.Sort();
                return result;
            }
        }
        #endregion

        #region Methods for Manual UI Processing
        public CustomerSummary GetCustomerSummary(string customerId)
        {
            using (var context = new NorthwindContext())
            {
                var customer = context.Customers.Find(customerId);
                if (customer == null)
                    throw new ArgumentException("Customer does not exist", nameof(customerId));
                return new CustomerSummary
                {
                    CompanyName = customer.CompanyName,
                    ContactName = $"{customer.ContactName} ({customer.ContactTitle})",
                    Phone = customer.Phone,
                    Fax = customer.Fax
                };
            }
        }

        public CustomerOrderWithDetails GetExistingOrder(int orderId)
        {
            using (var context = new NorthwindContext())
            {
                var result = (from data in context.Orders
                              where data.OrderID == orderId
                              select new CustomerOrderWithDetails
                              {
                                  OrderId = data.OrderID,
                                  Employee = data.Employee.FirstName + " " + data.Employee.LastName,
                                  OrderDate = data.OrderDate,
                                  RequiredDate = data.RequiredDate,
                                  ShippedDate = data.ShippedDate,
                                  Freight = data.Freight,
                                  Shipper = data.Shipper.CompanyName,
                                  OrderTotal = data.OrderDetails.Sum(x => x.Quantity * x.UnitPrice),
                                  Details = from item in data.OrderDetails
                                            select new CustomerOrderItem
                                            {
                                                OrderId = item.OrderID,
                                                ProductId = item.ProductID,
                                                ProductName = item.Product.ProductName,
                                                UnitPrice = item.UnitPrice,
                                                Quantity = item.Quantity,
                                                DiscountPercent = item.Discount,
                                                InStockQuantity = item.Product.UnitsInStock,
                                                QuantityPerUnit = item.Product.QuantityPerUnit
                                            }
                              }).Single();
                return result;
            }
        }
        #endregion

        #region Reporting
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<RegionalManager> GetRegionalManagers()
        {
            using (var context = new NorthwindContext())
            {
                var result = from emp in context.Employees
                             from data in emp.Territories
                             orderby data.Region.RegionDescription, emp.LastName, data.TerritoryDescription
                             select new RegionalManager
                             {
                                 Region = data.Region.RegionDescription,
                                 Territory = data.TerritoryDescription,
                                 TerritoryZip = data.TerritoryID,
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 City = emp.City,
                                 State = emp.Region
                             };
                return result.ToList();
            }
        }
        #endregion
    }
}
