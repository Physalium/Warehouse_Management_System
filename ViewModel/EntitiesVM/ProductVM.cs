using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel.EntitiesVM
{
    internal class ProductVM : BaseViewModel
    {
        private float price;

        public float Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string name;

        public ProductVM(Product x)
        {
            Price = x.Price;
            Name = x.Name;
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}