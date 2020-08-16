using System;
using System.Collections.Generic;

namespace Warehouse_Management.Model
{
    public partial class Truck
    {
        public Truck()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? WarehouseId { get; set; }
        public int ModelYear { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }

        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}