using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
        private ObservableCollection<ProductVM> products;
        private ObservableCollection<TruckVM> trucks;
        private ObservableCollection<SemitrailerVM> semitrailers;
        public WarehouseManagementData data { get; set; }

        public ObservableCollection<ProductVM> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ObservableCollection<TruckVM> Trucks
        {
            get { return trucks; }
            set
            {
                trucks = value;
                OnPropertyChanged(nameof(Trucks));
            }
        }

        public ObservableCollection<SemitrailerVM> Semitrailers
        {
            get { return semitrailers; }
            set
            {
                semitrailers = value;
                OnPropertyChanged(nameof(Semitrailers));
            }
        }

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