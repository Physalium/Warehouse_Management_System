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
            SelectedWarehouse = data.Warehouses[0];
        }

        private ProductVM selectedProduct;

        public ProductVM SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private SemitrailerVM selectedSemitrailer;

        public SemitrailerVM SelectedSemitrailer
        {
            get { return selectedSemitrailer; }
            set
            {
                selectedSemitrailer = value;
                OnPropertyChanged(nameof(SelectedSemitrailer));
            }
        }

        private TruckVM selectedTruck;

        public TruckVM SelectedTruck
        {
            get { return selectedTruck; }
            set
            {
                selectedTruck = value;
                OnPropertyChanged(nameof(SelectedTruck));
            }
        }

        private WarehouseVM selectedWarehouse;

        public WarehouseVM SelectedWarehouse
        {
            get { return selectedWarehouse; }
            set
            {
                selectedWarehouse = value;
                OnPropertyChanged(nameof(SelectedWarehouse));
            }
        }

        private ICommand addToWarehouseClick;

        public ICommand AddToWarehouse
        {
            get
            {
                if (addToWarehouseClick is null)
                {
                    addToWarehouseClick = new RelayCommand(
                           execute =>
                           {
                               data.LinkProductToWarehouse(selectedProduct, selectedWarehouse);
                               data.LinkSemitrailerToWarehouse(SelectedSemitrailer, selectedWarehouse);
                               data.LinkTruckToWarehouse(SelectedTruck, selectedWarehouse);
                               SelectedProduct = null;
                               SelectedSemitrailer = null;
                               SelectedTruck = null;
                           },
                           canExecute =>
                           {
                               return true;
                           });
                }
                return addToWarehouseClick;
            }
            set { addToWarehouseClick = value; }
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