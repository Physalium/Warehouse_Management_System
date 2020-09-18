using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Data;
using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.ViewModel
{
    using R = Properties.Resources;

    internal class SuppliesPanelVM : BaseViewModel
    {
        public WarehouseManagementData data { get; set; }

        public SuppliesPanelVM(WarehouseManagementData data)
        {
            this.data = data;
        }

        public string DateLabel { get; } = R.DateLabel;
        public string ValueLabel { get; } = R.ValueLabel;
        public string WarehouseLabel { get; } = R.WarehouseLabel;
        public string TruckLabel { get; } = R.TruckLabel;
        public string SemitrailerLabel { get; } = R.SemitrailerLabel;
        public string ProductsLabel { get; } = R.ProductsLabel;
        public string CustomerLabel { get; } = R.CustomerLabel;

    }
}