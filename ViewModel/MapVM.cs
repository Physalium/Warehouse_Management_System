using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

using Warehouse_Management.Data;
using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;
using Warehouse_Management.ViewModel.EntitiesVM;
using Warehouse_Management.ViewModel.MapItems;

namespace Warehouse_Management.ViewModel
{
    using R = Properties.Resources;

    internal class MapVM : BaseViewModel
    {
        public SidebarVM SidebarVM { get; set; }

        #region Props

        private BaseItem selectedItem;

        public BaseItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                if (value is WarehouseItem wh)
                {
                    SidebarVM.SelectedWarehouse = wh.Warehouse;
                }
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private bool sidebarButtonChecked;

        public bool SidebarButtonChecked
        {
            get { return sidebarButtonChecked; }
            set { sidebarButtonChecked = value; OnPropertyChanged(nameof(SidebarButtonChecked)); }
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

        #endregion Props

        #region Commands

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
                               SidebarButtonChecked = true;
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
        private WarehouseManagementData data;

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

        #endregion Commands

        public MapVM(WarehouseManagementData data)
        {
            this.data = data;
            mapImage = ByteArrayConverter.byteArrayToBitmap(R.PolandMapHQ);
            LoadData();
            SidebarVM = new SidebarVM();
            SelectedItem = MapItems[0];
        }

        private void LoadData()
        {
            foreach (WarehouseVM wh in data.Warehouses)
            {
                AddIcon(wh);
            }
            foreach (CustomerVM cs in data.Customers)
            {
                AddIcon2(cs);
            }
        }

        private void AddIcon(WarehouseVM wh)
        {
            if (wh == null)
            {
                return;
            }
            (double xPos, double yPos, string name) cc = MapConstants.Cities.Find(x => x.name.Equals(wh.City));
            WarehouseItem warehouse = new WarehouseItem(cc.xPos, cc.yPos, wh);
            mapItems.Add(warehouse);
        }

        private void AddIcon2(CustomerVM cs)
        {
            if (cs == null)
            {
                return;
            }
            (double xPos, double yPos, string name) cc2 = MapConstants.Cities.Find(x => x.name.Equals(cs.City));
            CustomerItem customer = new CustomerItem(cc2.xPos, cc2.yPos, cs);
            mapItems.Add(customer);
        }
    }
}