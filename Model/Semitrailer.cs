using System;
using System.Collections.Generic;

namespace Warehouse_Management.Model
{
    public partial class Semitrailer
    {
        public Semitrailer()
        {
            Orders = new HashSet<Order>();
        }

        public int? WarehouseId { get; set; }
        public int MaxVolume { get; set; }
        public int MaxAxleLoad { get; set; }
        public int Id { get; set; }

        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}