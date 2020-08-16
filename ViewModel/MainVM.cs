using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Data;
using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.ViewModel
{
    internal class MainVM : BaseViewModel
    {
        public MapVM MapVM { get; set; }

        public ObservableCollection<WarehouseVM> Warehouses { get; set; }
        public ObservableCollection<CityVM> Cities { get; set; }

        public MainVM()
        {
            LoadData();
            MapVM = new MapVM(this);
        }

        private void LoadData()
        {
            using (var db = new WarehousemanagementContext())
            {
                Warehouses = new ObservableCollection<WarehouseVM>();
                db.Warehouses.ToList().AsParallel().ForAll(x => Warehouses.Add(new WarehouseVM(x)));

                Cities = new ObservableCollection<CityVM>();
                db.Cities.ToList().AsParallel().ForAll(x => Cities.Add(new CityVM(x)));
            }
        }
    }
}