using System.Windows;

using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;
using Warehouse_Management.ViewModel.MapItems;

namespace Warehouse_Management.ViewModel
{
    internal class SidebarVM : BaseViewModel
    {
        public SidebarVM(MapVM mapVM)

        {
            this.mapVM = mapVM;
        }

        private bool sidebarVisible = false;
        public readonly MapVM mapVM;

        #region Props

        private WarehouseVM selectedWarehouse = null;

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