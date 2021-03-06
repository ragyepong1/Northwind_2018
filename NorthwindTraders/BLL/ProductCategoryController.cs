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
    public class ProductCategoryController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ProductCategory> AllProductsByCategory()
        {
            using (var context = new NorthwindContext())
            {
                // Produce a list of all the Products by Category for Northwind Traders
                var result = from cat in context.Categories // the query starts with the Database Entity
                             orderby cat.CategoryName
                             select new ProductCategory
                             {
                                 Name = cat.CategoryName,
                                 Description = cat.Description,
                                 Picture = cat.Picture,
                                 Products = from item in cat.Products // build subquery off of the cat item
                                            orderby item.ProductName
                                            where item.Discontinued == false
                                            select new ProductInfo
                                            {
                                                ID = item.ProductID,
                                                Name = item.ProductName,
                                                QuantityPerUnit = item.QuantityPerUnit,
                                                Price = item.UnitPrice,
                                                InStock = item.UnitsInStock
                                            }
                             };
                return result.ToList();
            }
        }
    }
}
