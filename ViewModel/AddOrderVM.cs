using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Warehouse_Management.Data;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.ViewModel
{
    using R = Properties.Resources;

    internal class AddOrderVM : BaseViewModel
    {
        public WarehouseManagementData data { get; set; }

        public AddOrderVM(WarehouseManagementData data)
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

        private ICommand createOrder;

        public ICommand CreateOrder
        {
            get
            {
                if (createOrder is null)
                {
                    createOrder = new RelayCommand(
                           execute =>
                           {
                               //data.CreateOrder();
                           },
                           canExecute =>
                           {
                               return true;
                           });
                }
                return createOrder;
            }
            set { createOrder = value; }
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