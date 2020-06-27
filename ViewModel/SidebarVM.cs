using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.MapItems;

namespace Warehouse_Management.ViewModel
{
    using CC = CityCoordConstants;
    using R = Properties.Resources;

    internal class SidebarVM : BaseViewModel
    {
        #region Props

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

        private bool sidebarVisible = false;

        public bool SidebarVisible
        {
            get
            {
                return sidebarVisible;
            }

            set
            {
                if (sidebarVisible != value) Application.Current.MainWindow.Width += !sidebarVisible ? SidebarWidth : -SidebarWidth;
                sidebarVisible = value;
                OnPropertyChanged(nameof(SidebarVisible));
            }
        }

        #endregion Props
    }
}