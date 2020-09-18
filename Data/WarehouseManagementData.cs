using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.Data
{
    internal class WarehouseManagementData
    {
        public ObservableCollection<WarehouseVM> Warehouses { get; set; }
        public ObservableCollection<CityVM> Cities { get; set; }
        public ObservableCollection<CustomerVM> Customers { get; set; }
        public ObservableCollection<ProductVM> Products { get; set; }
        public ObservableCollection<SemitrailerVM> Semitrailers { get; set; }
        public ObservableCollection<TruckVM> Trucks { get; set; }
        public ObservableCollection<OrderVM> Orders { get; set; }

        public WarehouseManagementData()
        {
            LoadCities();
            LoadCustomers();
            LoadProducts();
            LoadTrucks();
            LoadOrders();
            LoadSemitrailers();
            LoadWarehouses();
            LoadWarehouseRelations();
            LoadOrdersRelations();
        }

        #region LoadEntities

        private void LoadCities()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Cities = new ObservableCollection<CityVM>();
                db.Cities.ToList().ForEach(x => Cities.Add(new CityVM(x)));
            }
        }

        private void LoadOrders()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Orders = new ObservableCollection<OrderVM>();
                db.Orders.Include(x => x.Customer).Include(x => x.Warehouse).ToList().ForEach(x => Orders.Add(new OrderVM(x)));
            }
        }

        private void LoadCustomers()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Customers = new ObservableCollection<CustomerVM>();
                db.Customers.ToList().ForEach(x => Customers.Add(new CustomerVM(x)));
            }
        }

        private void LoadProducts()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Products = new ObservableCollection<ProductVM>();
                db.Products.Include(s => s.Warehouse).Include(s => s.Order).ToList().ForEach(x => Products.Add(new ProductVM(x)));
            }
        }

        private void LoadSemitrailers()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Semitrailers = new ObservableCollection<SemitrailerVM>();
                db.Semitrailers.Include(s => s.Orders).Include(s => s.Warehouse).ToList().ForEach(x => Semitrailers.Add(new SemitrailerVM(x)));
            }
        }

        private void LoadTrucks()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Trucks = new ObservableCollection<TruckVM>();
                db.Trucks.Include(s => s.
                Warehouse).Include(s => s.Orders).ToList().ForEach(x => Trucks.Add(new TruckVM(x)));
            }
        }

        private void LoadWarehouses()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Warehouses = new ObservableCollection<WarehouseVM>();
                db.Warehouses.Include(s => s.Products).Include(s => s.Trucks).Include(s => s.Semitrailers).ToList().ForEach(x => Warehouses.Add(new WarehouseVM(x)));
            }
        }

        #endregion LoadEntities

        #region LoadRelations

        private void LoadWarehouseRelations()
        {
            void LoadProducts(WarehouseVM wh)
            {
                if (wh.Model.Products.Count == 0) return;

                wh.Model.Products.ToList().ForEach(p =>
                {
                    var product = Products.Where(s => s.Model.Id == p.Id).FirstOrDefault();
                    {
                        product.Quantity = (from x in wh.Model.Products where x.Equals(p) select x).Count();
                        product.Warehouse = wh;
                    };
                    wh.Products.Add(product);
                });
            }
            void LoadTrucks(WarehouseVM wh)
            {
                if (wh.Model.Trucks.Count == 0) return;
                wh.Model.Trucks.ToList().ForEach(x =>
                {
                    var truck = Trucks.Where(t => t.DataModel.Id == x.Id).FirstOrDefault();
                    truck.Warehouse = wh;
                    wh.Trucks.Add(truck);
                });
            }
            void LoadSemitrailers(WarehouseVM wh)
            {
                if (wh.Model.Semitrailers.Count == 0) return;
                wh.Model.Semitrailers.ToList().ForEach(x =>
                {
                    var semitrailer = Semitrailers.Where(t => t.Model.Id == x.Id).FirstOrDefault();
                    semitrailer.Warehouse = wh;
                    wh.Semitrailers.Add(semitrailer);
                });
            }

            foreach (var wh in Warehouses)
            {
                LoadProducts(wh);
                LoadTrucks(wh);
                LoadSemitrailers(wh);
            }
        }

        private void LoadOrdersRelations()
        {
            void LoadProducts(OrderVM order)
            {
                order.Model.Products.ToList().ForEach(p =>
                {
                    var product = Products.Where(s => s.Model.Id == p.Id).FirstOrDefault();
                    {
                        product.Quantity = (from x in order.Model.Products where x.Equals(p) select x).Count();
                        product.Order = order;
                    };
                    order.Products.Add(product);
                });
            }

            void LoadWarehouse(OrderVM order)
            {
                if (order.Model.Warehouse == null) return;
                var warehouse = Warehouses.Where(s => s.Model.Id == order.Model.Warehouse.Id).FirstOrDefault();

                order.Warehouse = warehouse;
            }

            void LoadTruck(OrderVM order)
            {
                if (order.Model.Truck == null) return;
                var truck = Trucks.Where(s => s.DataModel.Id == order.Model.Truck.Id).FirstOrDefault();

                order.Truck = truck;
            }

            void LoadSemitrailer(OrderVM order)
            {
                if (order.Model.Semitrailer == null) return;
                var semitrailer = Semitrailers.Where(s => s.Model.Id == order.Model.Semitrailer.Id).FirstOrDefault();

                order.Semitrailer = semitrailer;
            }

            void LoadCustomer(OrderVM order)
            {
                if (order.Model.Customer == null) return;
                var customer = Customers.Where(s => s.Model.Id == order.Model.Customer.Id).FirstOrDefault();

                order.Customer = customer;
            }
            foreach (var o in Orders)
            {
                LoadProducts(o);
                LoadTruck(o);
                LoadCustomer(o);
                LoadWarehouse(o);
                LoadSemitrailer(o);
            }
        }

        #endregion LoadRelations

        public void AddToWarehouse<T>(T entity) where T : BaseViewModel
        {
        }
    }
}