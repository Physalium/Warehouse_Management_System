namespace Warehouse_Management.ViewModel.MapItems
{
    using Warehouse_Management.Model;

    using R = Properties.Resources;

    internal class WarehouseItem : BaseItem
    {
        public WarehouseItem()
        {
            base.ItemImage = ByteArrayConverter.byteArrayToBitmap(R.warehouseIcon);
        }
    }
}