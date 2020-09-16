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
        public WarehouseData warehouseData = new WarehouseData();
        public CustomersData customersData = new CustomersData();
        public OrdersData ordersData = new OrdersData();
        public MapVM MapVM { get; set; }
        public OrdersPanelVM OrdersPanelVM { get; set; }

        public MainVM()
        {
            MapVM = new MapVM(warehouseData, customersData);
            OrdersPanelVM = new OrdersPanelVM(ordersData);
        }

        public string MapTabHeader { get; } = R.MapTabHeader;
        public string OrdersTabHeader { get; } = R.OrderTabHeader;
        public string SupplyTabHeader { get; } = R.SupplyTabHeader;
    }
}