using System;
using System.Collections.Generic;

namespace Warehouse_Management.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }

        public virtual City CityNameNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}