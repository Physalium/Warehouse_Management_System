using System.Windows;

using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.MapItems;

namespace Warehouse_Management.ViewModel
{
    internal class SidebarVM : BaseViewModel
    {
        public SidebarVM(MainVM mainVM)
        {
            this.mainVM = mainVM;
        }

        private bool sidebarVisible = false;
        public readonly MainVM mainVM;

        #region Props

        private Warehouse selectedWarehouse;

        public Warehouse SelectedWarehouse
        {
            get { return selectedWarehouse; }
            set { selectedWarehouse = value; }
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