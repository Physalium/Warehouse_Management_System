using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.Data
{
    internal class WarehouseData
    {
        public ObservableCollection<WarehouseVM> Warehouses { get; set; }

        public WarehouseData()
        {
            LoadData();
        }

        private void LoadData()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Warehouses = new ObservableCollection<WarehouseVM>();
                db.Warehouses.Include(s => s.Products).Include(s => s.Trucks).Include(s => s.Semitrailers).ToList().ForEach(x => Warehouses.Add(new WarehouseVM(x)));
            }
        }

        public void AddWarehouse()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                //jakaś walidacja danych
                //Warehouses.Add(cos tam cos tam)
                //db.Add(cos tam cos tam)
                //db.SaveChanges();
            }
        }
    }
}