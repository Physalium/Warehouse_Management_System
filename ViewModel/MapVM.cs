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

    internal class MapVM : BaseViewModel
    {
        public SidebarVM sidebarVM = new SidebarVM();

        #region Props

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
                               sidebarVM.SidebarVisible = true;
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
                               sidebarVM.SidebarVisible = !sidebarVM.SidebarVisible;
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

        public MapVM()
        {
            mapImage = ByteArrayConverter.byteArrayToBitmap(R.PolandMapHQ);
            MapItems.Add(new WarehouseItem(CC.Katowice));
            MapItems.Add(new WarehouseItem(CC.Opole));
        }
    }
}