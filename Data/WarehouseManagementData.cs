using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.TextFormatting;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

using Warehouse_Management.Model;
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
                db.Orders.Include(x => x.Customer).Include(x => x.Warehouse).Include(x => x.Truck).Include(x => x.Semitrailer).Include(x => x.Products).ToList().ForEach(x => Orders.Add(new OrderVM(x)));
            }
        }

        private void LoadCustomers()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Customers = new ObservableCollection<CustomerVM>();
                db.Customers.Include(x => x.Orders).ToList().ForEach(x => Customers.Add(new CustomerVM(x)));
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
                db.Trucks.Include(s => s.Warehouse).Include(s => s.Orders).ToList().ForEach(x => Trucks.Add(new TruckVM(x)));
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
                    var product = Products.Where(s => s.DataModel.Id == p.Id).FirstOrDefault();
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
                    var semitrailer = Semitrailers.Where(t => t.DataModel.Id == x.Id).FirstOrDefault();
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
                    var product = Products.Where(s => s.DataModel.Id == p.Id).FirstOrDefault();
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
                var semitrailer = Semitrailers.Where(s => s.DataModel.Id == order.Model.Semitrailer.Id).FirstOrDefault();

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

        #region LinkToWarehouse

        public void LinkProductToWarehouse(ProductVM product, WarehouseVM warehouse)
        {
            if (product != null)
            {
                product.Warehouse = warehouse;
                product.Quantity += 1;
                warehouse.Products.Add(product);
                using (WarehousemanagementContext db = new WarehousemanagementContext())
                {
                    db.Products.Where(s => s.Id == product.DataModel.Id).FirstOrDefault().Warehouse = warehouse.Model;
                    db.SaveChanges();
                }
            }
        }

        public void LinkTruckToWarehouse(TruckVM truck, WarehouseVM warehouse)
        {
            if (truck != null)
            {
                truck.Warehouse = warehouse;
                warehouse.Trucks.Add(truck);

                using (WarehousemanagementContext db = new WarehousemanagementContext())
                {
                    db.Trucks.Where(s => s.Id == truck.DataModel.Id).FirstOrDefault().Warehouse = warehouse.Model;
                    db.SaveChanges();
                }
            }
        }

        public void LinkSemitrailerToWarehouse(SemitrailerVM semitrailer, WarehouseVM warehouse)
        {
            if (semitrailer != null)
            {
                semitrailer.Warehouse = warehouse;
                warehouse.Semitrailers.Add(semitrailer);
                using (WarehousemanagementContext db = new WarehousemanagementContext())
                {
                    db.Semitrailers.Where(s => s.Id == semitrailer.DataModel.Id).FirstOrDefault().Warehouse = warehouse.Model;
                    db.SaveChanges();
                }
            }
        }

        #endregion LinkToWarehouse

        #region Add items

        public bool AddProduct(string Name, float Price, int Weight, int Volume)
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                var product = new Product()
                {
                    Name = Name,
                    Price = Price,
                    Weight = Weight,
                    Volume = Volume
                };
                try
                {
                    Products.Add(new ProductVM(product));
                }
                catch (Exception)
                {
                    return false;
                }
                db.Products.Add(product);
                db.SaveChanges();

                return true;
            }
        }

        public bool AddTruck(string Model, int ModelYear, int Mileage, string Manafacturer)
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                var truck = new Truck()
                {
                    Model = Model,
                    ModelYear = ModelYear,
                    Mileage = Mileage,
                    Manufacturer = Manafacturer
                };
                try
                {
                    Trucks.Add(new TruckVM(truck));
                }
                catch (Exception)
                {
                    return false;
                }
                db.Trucks.Add(truck);
                db.SaveChanges();

                return true;
            }
        }

        public bool AddSemitrailer(int MaxAxleLoad, int MaxVolume)
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                var semitrailer = new Semitrailer()
                {
                    MaxAxleLoad = MaxAxleLoad,
                    MaxVolume = MaxVolume
                };

                db.Semitrailers.Add(semitrailer);
                try
                {
                    Semitrailers.Add(new SemitrailerVM(semitrailer));
                }
                catch (Exception)
                {
                    return false;
                }
                db.SaveChanges();

                return true;
            }
        }

        public bool CreateOrder(DateTime Date, float Value, IList<ProductVM> Products, WarehouseVM Warehouse, SemitrailerVM Semitrailer, TruckVM Truck, CustomerVM Customer)
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                var order = new Order()
                {
                    Customer = Customer.Model,
                    Date = Date,
                    Value = Value,
                    Warehouse = Warehouse.Model,
                    Semitrailer = Semitrailer.DataModel,
                    Truck = Truck.DataModel,
                };

                Products.ToList().ForEach(p =>
                {
                    order.Products.Add(p.DataModel);
                    p.DataModel.Order = order;
                });
                OrderVM orderVm = new OrderVM(order);
                orderVm.Customer = Customer;
                orderVm.Warehouse = Warehouse;
                orderVm.Truck = Truck;
                orderVm.Semitrailer = Semitrailer;
                foreach (var product in Products)
                {
                    orderVm.Products.Add(product);
                }

                Orders.Add(orderVm);

                Customer.Model.Orders.Add(order);
                Warehouse.Model.Orders.Add(order);
                Semitrailer.DataModel.Orders.Add(order);
                Truck.DataModel.Orders.Add(order);

                int new_num = 0;
                if (db.Orders.Any())
                {
                    new_num = db.Orders.Max(a => a.Id) + 1;
                }
                order.Id = new_num;
                db.Entry(order);

                db.SaveChanges();

                return true;
            }
        }

        #endregion Add items
    }
}