using System;
using System.Collections.Generic;

namespace Warehouse_Management.Model
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            Semitrailers = new HashSet<Semitrailer>();
            Trucks = new HashSet<Truck>();
        }

        public string City { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Semitrailer> Semitrailers { get; set; }
        public virtual ICollection<Truck> Trucks { get; set; }
    }
}