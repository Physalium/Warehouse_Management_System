using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Data;
using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel
{
    internal class MainVM : BaseViewModel
    {
        public MapVM MapVM { get; set; }

        public ObservableCollection<Warehouse> Warehouses { get; set; }
        public ObservableCollection<City> Cities { get; set; }

        public MainVM()
        {
            using (var db = new WarehousemanagementContext())
            {
                Warehouses = new ObservableCollection<Warehouse>(db.Warehouses.ToList());
                Cities = new ObservableCollection<City>(db.Cities.ToList());
            }
            MapVM = new MapVM(this);
        }
    }
}