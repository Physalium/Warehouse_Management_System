using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.Data
{
    internal class TrucksData
    {
        public ObservableCollection<TruckVM> Trucks { get; set; }

        public TrucksData()
        {
            LoadData();
        }

        private void LoadData()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Trucks = new ObservableCollection<TruckVM>();
                db.Trucks.Include(s => s.
                Warehouse).Include(s => s.Orders).ToList().ForEach(x => Trucks.Add(new TruckVM(x)));
            }
        }
    }
}