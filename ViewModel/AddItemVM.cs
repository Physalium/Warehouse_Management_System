﻿using System;
using System.Collections.Generic;
using System.Linq;

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

        private void UpdateFields()
        {
            FirstField = SecondField = ThirdField = FourthField = "";
            switch (selectedItem)
            {
                case "Product":
                    FirstFieldName = "Name";
                    SecondFieldName = "Price";
                    ThirdFieldName = "Volume";
                    ThirdFieldVis = true;
                    FourthFieldVis = true;
                    FourthFieldName = "Weight";
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