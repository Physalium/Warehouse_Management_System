namespace Warehouse_Management.ViewModel.MapItems
{
    using R = Properties.Resources;
    class WarehouseItem : BaseItem
    {
        public WarehouseItem()
        {
            base.ItemImage = createBitmap(R.warehouseIcon);
        }

        #region Props

            
        #endregion
    }
}