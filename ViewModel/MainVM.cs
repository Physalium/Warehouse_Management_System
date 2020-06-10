using System;
using System.Collections.Generic;
using System.Text;

using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel
{
    class MainVM : BaseViewModel
    {
        private MapVM mapVM = new MapVM();

        public MapVM MapVM
        {
            get => mapVM; set { mapVM = value; OnPropertyChanged(nameof(MapVM)); }
        }
    }
}
