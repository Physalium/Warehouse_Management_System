using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            SelectedCustomer = data.Customers[0];
            SelectedDate = DateTime.Now;
        }

        private IList<ProductVM> selectedProducts;

        public IList<ProductVM> SelectedProducts
        {
            get { return selectedProducts; }
            set
            {
                selectedProducts = value;
                OnPropertyChanged(nameof(SelectedProducts));
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

        private DateTime selectedDate;

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
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

        private CustomerVM selectedCustomer;

        public CustomerVM SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
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
                               try
                               {
                                   data.CreateOrder(SelectedDate, SelectedProducts.Sum(x => x.Price), SelectedProducts, SelectedWarehouse, SelectedSemitrailer, SelectedTruck, SelectedCustomer);
                               }
                               catch (Exception e)
                               {
                                   Message = R.ErrorInvalidArguments;
                                   return;
                               }
                               Message = R.ItemAddSuccess;
                           },
                           canExecute =>
                           {
                               if (SelectedCustomer != null && SelectedDate != null && SelectedSemitrailer != null && SelectedProducts != null && SelectedTruck != null)
                               {
                                   return true;
                               }
                               return false;
                           });
                }
                return createOrder;
            }
            set { createOrder = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
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