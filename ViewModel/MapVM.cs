using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

using System.Linq;
using Warehouse_Management.Data;
using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.MapItems;
using System;

namespace Warehouse_Management.ViewModel
{
    using CC = MapConstants;
    using R = Properties.Resources;

    internal class MapVM : BaseViewModel
    {
        public readonly SidebarVM SidebarVM;
        public readonly MainVM mainVM;

        #region Props

        private WarehouseItem selectedItem;

        public WarehouseItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private BitmapImage mapImage;

        public BitmapImage MapImage
        {
            get { return mapImage; }
            set
            {
                mapImage = value;
                OnPropertyChanged(nameof(MapImage));
            }
        }

        private ObservableCollection<BaseItem> mapItems = new ObservableCollection<BaseItem>();

        public ObservableCollection<BaseItem> MapItems
        {
            get { return mapItems; }
            set
            {
                mapItems = value;
                OnPropertyChanged(nameof(MapItems));
            }
        }

        private ICommand itemClick;

        public ICommand ItemClick
        {
            get
            {
                if (itemClick is null)
                {
                    itemClick = new RelayCommand(
                           execute =>
                           {
                               SidebarVM.SidebarVisible = true;
                           },
                           canExecute =>
                           {
                               return true;
                           });
                }
                return itemClick;
            }
            set { itemClick = value; }
        }

        private ICommand buttonClick;

        public ICommand ButtonClick
        {
            get
            {
                if (buttonClick is null)
                {
                    buttonClick = new RelayCommand(
                           execute =>
                           {
                               SidebarVM.SidebarVisible = !SidebarVM.SidebarVisible;
                           },
                           canExecute =>
                           {
                               return true;
                           });
                }
                return buttonClick;
            }
            set { buttonClick = value; }
        }

        #endregion Props

        public MapVM(MainVM mainVM)
        {
            this.mainVM = mainVM;
            mapImage = ByteArrayConverter.byteArrayToBitmap(R.PolandMapHQ);
            LoadData();
            SidebarVM = new SidebarVM(mainVM);
        }

        private void LoadData()
        {
            foreach (var wh in mainVM.Warehouses)
            {
                AddWarehouse(wh);
            }
            return;
        }

        private void AddWarehouse(Warehouse wh)
        {
            var cc = MapConstants.Cities.Find(x => x.name.Equals(wh.City));
            var warehouse = new WarehouseItem(cc.xPos, cc.yPos, wh);
            mapItems.Add(warehouse);
        }
    }
}