using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.Data
{
    internal class SemitrailersData
    {
        public ObservableCollection<SemitrailerVM> Semitrailers { get; set; }

        public SemitrailersData()
        {
            LoadData();
        }

        private void LoadData()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Semitrailers = new ObservableCollection<SemitrailerVM>();
                db.Semitrailers.Include(s => s.Orders).Include(s => s.Warehouse).ToList().ForEach(x => Semitrailers.Add(new SemitrailerVM(x)));
            }
        }
    }
}