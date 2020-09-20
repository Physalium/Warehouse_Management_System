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
        public WarehouseManagementData data;
        public MapVM MapVM { get; set; }
        public OrdersPanelVM OrdersPanelVM { get; set; }

        public SuppliesPanelVM SuppliesPanelVM { get; set; }

        public AddItemVM AddItemVM { get; set; }

        public MainVM()
        {
            data = new WarehouseManagementData();
            MapVM = new MapVM(data);
            OrdersPanelVM = new OrdersPanelVM(data);
            SuppliesPanelVM = new SuppliesPanelVM(data);
            AddItemVM = new AddItemVM(data);
        }

        public string MapTabHeader { get; } = R.MapTabHeader;
        public string OrdersTabHeader { get; } = R.OrderTabHeader;
        public string SupplyTabHeader { get; } = R.SupplyTabHeader;
        public string AddItemTabHeader { get; } = R.AddItemTabHeader;
    }
}