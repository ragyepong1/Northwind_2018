﻿using NorthwindTraders.DAL;
using NorthwindTraders.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NorthwindTraders.BLL.CRUD
{
    [DataObject]
    public class ShipperController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Shipper> ListAllShippers()
        {
            using (var context = new NorthwindContext())
            {
                return context.Shippers.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddShipper(Shipper info)
        {
            using (var context = new NorthwindContext())
            {
                context.Shippers.Add(info);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateShipper(Shipper info)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Entry(info); // Associate the info passed in with the db
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void RemoveShipper(Shipper info)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Shippers.Find(info.ShipperID);
                context.Shippers.Remove(existing);
                context.SaveChanges();
            }
        }
    }
}
