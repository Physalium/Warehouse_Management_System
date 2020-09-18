using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel.EntitiesVM
{
    internal class ProductVM : BaseViewModel
    {
        public Product Model;

        public ProductVM(Product x)
        {
            Model = x;
            Price = x.Price;
            Name = x.Name;
            Volume = x.Volume;
            Weight = x.Weight;
        }

        #region Properties

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

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private int weight;

        public int Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private int volume;

        public int Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }

        #endregion Properties
    }
}