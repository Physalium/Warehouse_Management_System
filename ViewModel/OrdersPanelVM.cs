using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Warehouse_Management.Data;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.ViewModel
{
    internal class OrdersPanelVM : BaseViewModel
    {
        public readonly MainVM mainVM;

        private ObservableCollection<OrderVM> orders;

        public ObservableCollection<OrderVM> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public OrdersPanelVM(MainVM mainVM)
        {
            this.mainVM = mainVM;
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new WarehouseManagementData())
            {
                Orders = new ObservableCollection<OrderVM>();
                db.OrderRepo.GetAll().ForEach(x => Orders.Add(new OrderVM(x)));
            }
        }
    }
}