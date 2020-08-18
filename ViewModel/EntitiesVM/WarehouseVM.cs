using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;

using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel.EntitiesVM
{
    internal class WarehouseVM : BaseViewModel
    {
        #region Properties

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

        private ObservableCollection<TruckVM> trucks = new ObservableCollection<TruckVM>();

        public ObservableCollection<TruckVM> Trucks
        {
            get { return trucks; }
            set
            {
                trucks = value;
                OnPropertyChanged(nameof(Trucks));
            }
        }

        private ObservableCollection<SemitrailerVM> semitrailers = new ObservableCollection<SemitrailerVM>();

        public ObservableCollection<SemitrailerVM> Semitrailers
        {
            get { return semitrailers; }
            set
            {
                semitrailers = value;
                OnPropertyChanged(nameof(Semitrailers));
            }
        }

        #endregion Properties

        public WarehouseVM(Warehouse x)
        {
            WarehouseName = x.Name;
            City = x.City;
            LoadProducts(x);
            LoadTrucks(x);
            LoadSemitrailers(x);
        }

        private void LoadProducts(Warehouse wh)
        {
            wh.Products.ToList().ForEach(x =>
            {
                var product = new ProductVM(x)
                {
                    Quantity = (from p in wh.Products where p.Equals(x) select p).Count()
                };
                Products.Add(product);
            });
        }

        private void LoadTrucks(Warehouse wh)
        {
            wh.Trucks.ToList().ForEach(x =>
            {
                var truck = new TruckVM(x);
                Trucks.Add(truck);
            });
        }

        private void LoadSemitrailers(Warehouse wh)
        {
            wh.Semitrailers.ToList().ForEach(x =>
            {
                var sm = new SemitrailerVM(x)
                {
                    Quantity = (from s in wh.Semitrailers
                                where s.Equals(x)
                                select s).Count()
                };
                Semitrailers.Add(sm);
            });
        }
    }
}