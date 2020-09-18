using System;
using System.Collections.Generic;
using System.Text;

using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel.EntitiesVM
{
    internal class SemitrailerVM : BaseViewModel
    {
        public Semitrailer DataModel { get; set; }
        public WarehouseVM Warehouse { get; set; }

        public SemitrailerVM(Semitrailer st)
        {
            DataModel = st;
            Id = st.Id;
            MaxAxleLoad = st.MaxAxleLoad;
            MaxVolume = st.MaxVolume;
        }

        #region Properties

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int maxVolume;

        public int MaxVolume
        {
            get { return maxVolume; }
            set
            {
                maxVolume = value;
                OnPropertyChanged(nameof(MaxVolume));
            }
        }

        private int maxAxleLoad;

        public int MaxAxleLoad
        {
            get { return maxAxleLoad; }
            set
            {
                maxAxleLoad = value;
                OnPropertyChanged(nameof(MaxAxleLoad));
            }
        }
    }

    #endregion Properties
}