using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel.EntitiesVM
{
    internal class TruckVM : BaseViewModel
    {
        #region Properties

        private int modelYear;

        public int ModelYear
        {
            get { return modelYear; }
            set
            {
                modelYear = value;
                OnPropertyChanged(nameof(ModelYear));
            }
        }

        private string manafacturer;

        public string Manafacturer
        {
            get { return manafacturer; }
            set
            {
                manafacturer = value;
                OnPropertyChanged(nameof(Manafacturer));
            }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged(nameof(Model)); }
        }

        private int mileage;

        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; OnPropertyChanged(nameof(Mileage)); }
        }

        #endregion Properties

        public Truck DataModel;

        public TruckVM(Truck truck)
        {
            DataModel = truck;
            Mileage = truck.Mileage;
            Model = truck.Model;
            ModelYear = truck.ModelYear;
            Manafacturer = truck.Manufacturer;
        }
    }
}