using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Warehouse_Management.Data;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.ViewModel
{
    using R = Properties.Resources;

    internal class AddItemVM : BaseViewModel
    {
        public WarehouseManagementData Data { get; }

        public AddItemVM(WarehouseManagementData data)
        {
            Data = data;
            SelectedItem = Items.First();
            ButtonText = "Add";
        }

        private ICommand addItem;

        public ICommand AddItem
        {
            get
            {
                if (addItem is null)
                {
                    addItem = new RelayCommand(
                           execute =>
                           {
                               switch (selectedItem)
                               {
                                   case "Product":
                                       try
                                       {
                                           Data.AddProduct(FirstField, float.Parse(SecondField), int.Parse(ThirdField), int.Parse(FourthField));
                                       }
                                       catch (Exception)
                                       {
                                           Message = R.ErrorInvalidArguments;
                                           break;
                                       }
                                       Message = R.ItemAddSuccess;
                                       break;

                                   case "Truck":
                                       try
                                       {
                                           Data.AddTruck(FirstField, int.Parse(SecondField), int.Parse(ThirdField), FourthField);
                                       }
                                       catch (Exception)
                                       {
                                           Message = R.ErrorInvalidArguments;
                                           break;
                                       }
                                       Message = R.ItemAddSuccess;
                                       break;

                                   case "Semitrailer":
                                       try
                                       {
                                           Data.AddSemitrailer(int.Parse(FirstField), int.Parse(SecondField));
                                       }
                                       catch (Exception)
                                       {
                                           Message = R.ErrorInvalidArguments;
                                           break;
                                       }
                                       Message = R.ItemAddSuccess;
                                       break;
                               }
                           },
                           canExecute =>
                           {
                               var FirstAndSecond = (!String.IsNullOrWhiteSpace(FirstField) && !String.IsNullOrWhiteSpace(SecondField));
                               var ThirdAndFourth = (!String.IsNullOrWhiteSpace(ThirdField) && !String.IsNullOrWhiteSpace(FourthField));

                               if (FirstAndSecond && ThirdAndFourth) return true;
                               if (FirstAndSecond && !(ThirdFieldVis)) return true;
                               return false;
                           });
                }
                return addItem;
            }
            set { addItem = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private string buttonText;

        public string ButtonText
        {
            get { return buttonText; }
            set
            {
                buttonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        #region Items

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
                UpdateFields();
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        #endregion Items

        #region Field Names

        private string firstFieldName;

        public string FirstFieldName
        {
            get { return firstFieldName; }
            set
            {
                firstFieldName = value;
                OnPropertyChanged(nameof(FirstFieldName));
            }
        }

        private string secondFieldName;

        public string SecondFieldName
        {
            get { return secondFieldName; }
            set
            {
                secondFieldName = value;
                OnPropertyChanged(nameof(SecondFieldName));
            }
        }

        private string thirdFieldName;

        public string ThirdFieldName
        {
            get { return thirdFieldName; }
            set
            {
                thirdFieldName = value;
                OnPropertyChanged(nameof(ThirdFieldName));
            }
        }

        private string fourthFieldName;

        public string FourthFieldName
        {
            get { return fourthFieldName; }
            set
            {
                fourthFieldName = value;
                OnPropertyChanged(nameof(FourthFieldName));
            }
        }

        #endregion Field Names

        #region private methods

        private void UpdateFields()
        {
            FirstField = SecondField = ThirdField = FourthField = "";
            switch (selectedItem)
            {
                case "Product":
                    FirstFieldName = "Name";
                    SecondFieldName = "Price";
                    ThirdFieldName = "Weight";
                    ThirdFieldVis = true;
                    FourthFieldVis = true;
                    FourthFieldName = "Volume";
                    break;

                case "Truck":
                    FirstFieldName = "Model";
                    SecondFieldName = "Model year";
                    ThirdFieldName = "Mileage";
                    FourthFieldName = "Manafacturer";
                    ThirdFieldVis = true;
                    FourthFieldVis = true;
                    break;

                case "Semitrailer":
                    FirstFieldName = "Max axle load";
                    SecondFieldName = "Max volume";
                    ThirdFieldName = "";
                    FourthFieldName = "";
                    ThirdFieldVis = false;
                    FourthFieldVis = false;
                    break;
            }
        }

        #endregion private methods

        #region Field visibility

        private bool fourthFieldVis;
        private bool thirdFieldVis;

        public bool FourthFieldVis
        {
            get => fourthFieldVis; set
            {
                fourthFieldVis = value;
                OnPropertyChanged(nameof(FourthFieldVis));
            }
        }

        public bool ThirdFieldVis
        {
            get => thirdFieldVis; set
            {
                thirdFieldVis = value; OnPropertyChanged(nameof(ThirdFieldVis));
            }
        }

        #endregion Field visibility

        #region Fields

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

        #endregion Fields
    }
}