using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;

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

        private string warehouseName;

        public string WarehouseName
        {
            get { return warehouseName; }
            set
            {
                warehouseName = value;
                OnPropertyChanged(nameof(WarehouseName));
            }
        }

        private ObservableCollection<ProductVM> products;

        public WarehouseVM(Warehouse x)
        {
            WarehouseName = x.Name;
            City = x.City;
            LoadProducts(x);
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

        private void LoadProducts(Warehouse wh)
        {
            Products = new ObservableCollection<ProductVM>();
            wh.Products.ToList().AsParallel().ForAll(x =>
            {
                var product = new ProductVM(x)
                {
                    Quantity = (from p in wh.Products where p.Equals(x) select p).Count()
                };
                Products.Add(product);
            });
        }
    }
}