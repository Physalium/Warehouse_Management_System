using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management.Model
{
    public partial class City
    {
        public City()
        {
            Customers = new HashSet<Customer>();
            Warehouses = new HashSet<Warehouse>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Longitude { get; set; }

        [Required]
        public float Latitude { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}