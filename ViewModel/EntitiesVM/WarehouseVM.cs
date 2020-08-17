using System.Collections.ObjectModel;
using System.Linq;

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
            Products = new ObservableCollection<ProductVM>();
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