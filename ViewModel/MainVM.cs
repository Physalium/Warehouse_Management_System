using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Data;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.ViewModel
{
    using R = Properties.Resources;

    internal class MainVM : BaseViewModel
    {
        public MapVM MapVM { get; set; }
        public OrdersPanelVM OrdersPanelVM { get; set; }

        public ObservableCollection<WarehouseVM> Warehouses { get; set; }
        public ObservableCollection<CityVM> Cities { get; set; }
        public ObservableCollection<CustomerVM> Customers { get; set; }

        public MainVM()
        {
            LoadData();
            MapVM = new MapVM(this);
            OrdersPanelVM = new OrdersPanelVM(this);
        }

        private void LoadData()
        {
            using (WarehouseManagementData db = new WarehouseManagementData())
            {
                Warehouses = new ObservableCollection<WarehouseVM>();
                db.WarehouseRepo.GetAll().ForEach(x => Warehouses.Add(new WarehouseVM(x)));

                Cities = new ObservableCollection<CityVM>();
                db.CityRepo.GetAll().ForEach(x => Cities.Add(new CityVM(x)));

                Customers = new ObservableCollection<CustomerVM>();
                db.CustomerRepo.GetAll().ForEach(x => Customers.Add(new CustomerVM(x)));
            }
        }

        public string MapTabHeader { get; } = R.MapTabHeader;
        public string OrdersTabHeader { get; } = R.OrderTabHeader;
        public string SupplyTabHeader { get; } = R.SupplyTabHeader;
    }
}