using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Data;
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
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Warehouses = new ObservableCollection<WarehouseVM>();
                db.Warehouses.Include(s => s.Products).ToList().ForEach(x => Warehouses.Add(new WarehouseVM(x)));

                Cities = new ObservableCollection<CityVM>();
                db.Cities.ToList().ForEach(x => Cities.Add(new CityVM(x)));
            }
        }
    }
}