namespace Warehouse_Management.ViewModel.MapItems
{
    using Warehouse_Management.Model;

    using R = Properties.Resources;

    internal class WarehouseItem : BaseItem
    {
        public WarehouseItem((double xPos, double yPos) cc) : base(cc)
        {
            base.ItemImage = ByteArrayConverter.byteArrayToBitmap(R.warehouseIcon);
            base.Width = 0.03;
            base.Height = 0.03;
        }
    }
}