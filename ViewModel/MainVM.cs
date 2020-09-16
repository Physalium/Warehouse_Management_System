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
        public WarehouseManagementData data = new WarehouseManagementData();
        public MapVM MapVM { get; set; }
        public OrdersPanelVM OrdersPanelVM { get; set; }

        public MainVM()
        {
            MapVM = new MapVM(data);
            OrdersPanelVM = new OrdersPanelVM(data);
        }

        public string MapTabHeader { get; } = R.MapTabHeader;
        public string OrdersTabHeader { get; } = R.OrderTabHeader;
    }
}