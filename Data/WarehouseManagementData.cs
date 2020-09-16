using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.Data
{
    internal class WarehouseManagementData
    {
        public ObservableCollection<WarehouseVM> Warehouses { get; set; }
        public ObservableCollection<CityVM> Cities { get; set; }
        public ObservableCollection<CustomerVM> Customers { get; set; }

        // dodanie ciężarówek itd

        public WarehouseManagementData()
        {
            LoadData();
        }

        private void LoadData()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Warehouses = new ObservableCollection<WarehouseVM>();
                db.Warehouses.Include(s => s.Products).Include(s => s.Trucks).Include(s => s.Semitrailers).ToList().ForEach(x => Warehouses.Add(new WarehouseVM(x)));

                Cities = new ObservableCollection<CityVM>();
                db.Cities.ToList().ForEach(x => Cities.Add(new CityVM(x)));

                Customers = new ObservableCollection<CustomerVM>();
                db.Customers.ToList().ForEach(x => Customers.Add(new CustomerVM(x)));
            }
        }
    }
}