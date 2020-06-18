using Warehouse_Management.Model;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel
{
    internal class MainVM : BaseViewModel
    {
        private MapVM mapVM = new MapVM();

        public MapVM MapVM
        {
            get => mapVM; set { mapVM = value; OnPropertyChanged(nameof(MapVM)); }
        }
    }
}