namespace Warehouse_Management.ViewModel.MapItems
{
    using R = Properties.Resources;

    internal class WarehouseItem : BaseItem
    {
        public WarehouseItem()
        {
            base.ItemImage = createBitmap(R.warehouseIcon);
        }
    }
}