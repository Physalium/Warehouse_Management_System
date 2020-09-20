using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Warehouse_Management.Data;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel
{
    internal class AddItemVM : BaseViewModel
    {
        public WarehouseManagementData Data { get; }

        public AddItemVM(WarehouseManagementData data)
        {
            Data = data;
            SelectedItem = Items.First();
        }

        private enum SelectableItems
        {
            Product,
            Truck,
            Semitrailer,
            Order
        }

        public IEnumerable<string> Items
        {
            get
            {
                return Enum.GetNames(typeof(SelectableItems));
            }
        }

        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private string firstField;

        public string FirstField
        {
            get { return firstField; }
            set
            {
                firstField = value;
                OnPropertyChanged(nameof(FirstField));
            }
        }

        private string secondfield;

        public string SecondField
        {
            get { return secondfield; }
            set
            {
                secondfield = value;
                OnPropertyChanged(nameof(SecondField));
            }
        }

        private string thirdField;

        public string ThirdField
        {
            get { return thirdField; }
            set
            {
                thirdField = value;
                OnPropertyChanged(nameof(ThirdField));
            }
        }

        private string fourthField;

        public string FourthField
        {
            get { return fourthField; }
            set
            {
                fourthField = value;
                OnPropertyChanged(nameof(FourthField));
            }
        }
    }
}