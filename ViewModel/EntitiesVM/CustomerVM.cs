using System.Collections.ObjectModel;
using System.Linq;

using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel.EntitiesVM
{
    internal class CustomerVM : BaseViewModel
    {
        public Customer Model;

        public CustomerVM(Customer customer)
        {
            Model = customer;
            Name = customer.Name;
            City = customer.CityName;
            LoadOrders(customer);
        }

        #region Props

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string city;

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private ObservableCollection<OrderVM> orders = new ObservableCollection<OrderVM>();

        public ObservableCollection<OrderVM> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private void LoadOrders(Customer customer)
        {
            customer.Orders.ToList().ForEach(x =>
            {
                var order = new OrderVM(x)
                {
                    Quantity = (from o in customer.Orders where o.Equals(x) select o).Count()
                };
                Orders.Add(order);
            });
        }

        #endregion Props
    }
}