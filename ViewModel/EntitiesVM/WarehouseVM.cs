using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel.EntitiesVM
{
    internal class WarehouseVM : BaseViewModel
    {
        private string city;

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private ObservableCollection<ProductVM> products;

        public WarehouseVM(Warehouse x)
        {
            Name = x.Name;
            City = x.City;
            x.Products.ToList().AsParallel().ForAll(x => Products.Add(new ProductVM(x)));
        }

        public ObservableCollection<ProductVM> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
    }
}