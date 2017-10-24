﻿using NorthwindTraders.DAL;
using NorthwindTraders.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace NorthwindTraders.BLL.CRUD
{
    [DataObject]
    public class TerritoryController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Territory> ListAllTerritories()
        {
            using (var context = new NorthwindContext())
            {
                return context.Territories.Include(x => x.Region).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void AddTerritory(Territory data)
        {
            using (var context = new NorthwindContext())
            {
                // The Territory Primary Key is not auto-generated by the database
                int len = data.TerritoryDescription.Trim().Length;
                data.TerritoryID = data.TerritoryDescription.Trim().Substring(0, len > 20 ? 20 : len);
                context.Territories.Add(data);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateTerritory(Territory data)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Entry(data);
                existing.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteTerritory(Territory data)
        {
            using (var context = new NorthwindContext())
            {
                var existing = context.Territories.Find(data.TerritoryID);
                context.Territories.Remove(existing);
                context.SaveChanges();
            }
        }
    }
}
