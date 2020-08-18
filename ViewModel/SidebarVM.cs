using System.Windows;

using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;

namespace Warehouse_Management.ViewModel
{
    internal class SidebarVM : BaseViewModel
    {
        public SidebarVM(MapVM mapVM)
        {
            this.MapVM = mapVM;
        }

        public readonly MapVM MapVM;

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

        private string productsLabel = Properties.Resources.ProductsLabel;

        public string ProductsLabel
        {
            get { return productsLabel; }
            set
            {
                productsLabel = value;
                OnPropertyChanged(nameof(ProductsLabel));
            }
        }

        private string trucksLabel = Properties.Resources.TrucksLabel;

        public string TrucksLabel
        {
            get { return trucksLabel; }
            set
            {
                trucksLabel = value;
                OnPropertyChanged(nameof(TrucksLabel));
            }
        }

        private string semitrailersLabel = Properties.Resources.SemitrailersLabel;

        public string SemitrailersLabel
        {
            get { return semitrailersLabel; }
            set
            {
                semitrailersLabel = value;
                OnPropertyChanged(nameof(SemitrailersLabel));
            }
        }

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