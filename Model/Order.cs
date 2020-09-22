using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management.Model
{
    public partial class Order
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public float Value { get; set; }
        public int CustomerId { get; set; }
        public int WarehouseId { get; set; }
        public int TruckId { get; set; }
        public int SemitrailerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Semitrailer Semitrailer { get; set; }
        public virtual Truck Truck { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}