using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Model;

namespace Warehouse_Management.Data.Repositories
{
    internal class OrderRepo
    {
        private readonly WarehousemanagementContext db;

        public OrderRepo(WarehousemanagementContext db)
        {
            this.db = db;
        }

        public List<Order> GetAll()
        {
            return db.Orders.Include(s => s.Products).ToList();
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}