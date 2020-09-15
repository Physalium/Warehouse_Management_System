using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Model;

namespace Warehouse_Management.Data.Repositories
{
    public class TruckRepo
    {
        private readonly WarehousemanagementContext db;

        public TruckRepo(WarehousemanagementContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}