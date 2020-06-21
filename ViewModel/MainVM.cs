using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel
{
    internal class MainVM : BaseViewModel
    {
        private MapVM mapVM = new MapVM();

        public MapVM MapVM
        {
            get => mapVM;
        }
    }
}