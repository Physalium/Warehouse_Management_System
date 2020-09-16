using System.Windows;

using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.ViewModel
{
    internal class SidebarVM : BaseViewModel
    {
        #region Props

        private WarehouseVM selectedWarehouse;

        public WarehouseVM SelectedWarehouse
        {
            get { return selectedWarehouse; }
            set
            {
                selectedWarehouse = value;
                OnPropertyChanged(nameof(SelectedWarehouse));
            }
        }

        private int sidebarWidth = 400;

        public int SidebarWidth
        {
            get { return sidebarWidth; }
            set
            {
                sidebarWidth = value;
                OnPropertyChanged(nameof(SidebarWidth));
            }
        }

        public string ProductsLabel { get; } = Properties.Resources.ProductsLabel;

        public string TrucksLabel { get; } = Properties.Resources.TrucksLabel;

        public string SemitrailersLabel { get; } = Properties.Resources.SemitrailersLabel;

        private bool sidebarVisible = false;

        public bool SidebarVisible
        {
            get
            {
                return sidebarVisible;
            }

            set
            {
                if (sidebarVisible != value)
                {
                    Application.Current.MainWindow.Width += !sidebarVisible ? SidebarWidth : -SidebarWidth;
                }

                sidebarVisible = value;
                OnPropertyChanged(nameof(SidebarVisible));
            }
        }

        #endregion Props
    }
}