using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel.EntitiesVM
{
    internal class OrderVM : BaseViewModel
    {
        public OrderVM(Order order)
        {
            Date = order.Date;
            Value = order.Value;
            LoadProducts(order);
        }

        #region Props

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private float value;

        public float Value
        {
            get { return value; }
            set { this.value = value; OnPropertyChanged(nameof(Value)); }
        }

        private ObservableCollection<ProductVM> products = new ObservableCollection<ProductVM>();

        public ObservableCollection<ProductVM> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private WarehouseVM warehouse;

        public WarehouseVM Warehouse
        {
            get { return warehouse; }
            set
            {
                warehouse = value;
                OnPropertyChanged(nameof(Warehouse));
            }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private SemitrailerVM semitrailer;

        public SemitrailerVM Semitrailer
        {
            get { return semitrailer; }
            set
            {
                semitrailer = value;
                OnPropertyChanged(nameof(Semitrailer));
            }
        }

        private TruckVM truck;

        public TruckVM Truck
        {
            get { return truck; }
            set
            {
                truck = value;
                OnPropertyChanged(nameof(Truck));
            }
        }

        private CustomerVM customer;

        public CustomerVM Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        #endregion Props

        private void LoadProducts(Order order)
        {
            order.Products.ToList().ForEach(x =>
            {
                var product = new ProductVM(x)
                {
                    Quantity = (from p in order.Products where p.Equals(x) select p).Count()
                };
                Products.Add(product);
            });
        }
    }
}