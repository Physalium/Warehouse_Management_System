using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Model;

namespace Warehouse_Management.Data.Repositories
{
    public class WarehouseRepo
    {
        private readonly WarehousemanagementContext db;

        public WarehouseRepo(WarehousemanagementContext db)
        {
            this.db = db;
        }

        public List<Warehouse> GetAll()
        {
            return db.Warehouses.Include(s => s.Products).Include(s => s.Trucks).Include(s => s.Semitrailers).ToList();
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}