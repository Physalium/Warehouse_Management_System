using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.Data
{
    internal class ProductsData
    {
        public ObservableCollection<ProductVM> Products { get; set; }

        public ProductsData()
        {
            LoadData();
        }

        private void LoadData()
        {
            using (WarehousemanagementContext db = new WarehousemanagementContext())
            {
                Products = new ObservableCollection<ProductVM>();
                db.Products.Include(s => s.Warehouse).Include(s => s.Order).ToList().ForEach(x => Products.Add(new ProductVM(x)));
            }
        }
    }
}