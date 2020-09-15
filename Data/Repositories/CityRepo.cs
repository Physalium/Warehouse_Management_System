using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Warehouse_Management.Model;

namespace Warehouse_Management.Data.Repositories
{
    public class CityRepo
    {
        private readonly WarehousemanagementContext db;

        public CityRepo(WarehousemanagementContext db)
        {
            this.db = db;
        }

        public List<City> GetAll()
        {
            return db.Cities.ToList();
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}