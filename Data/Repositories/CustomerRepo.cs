using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Warehouse_Management.Model;

namespace Warehouse_Management.Data.Repositories
{
    public class CustomerRepo
    {
        private readonly WarehousemanagementContext db;

        public CustomerRepo(WarehousemanagementContext db)
        {
            this.db = db;
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}