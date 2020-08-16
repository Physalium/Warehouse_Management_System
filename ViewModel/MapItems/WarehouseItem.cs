namespace Warehouse_Management.ViewModel.MapItems
{
    using Warehouse_Management.Model;

    using R = Properties.Resources;

    internal class WarehouseItem : BaseItem
    {
        public Warehouse Warehouse { get; }

        public WarehouseItem(double xPos, double yPos, Warehouse warehouse) : base(xPos, yPos)
        {
            base.ItemImage = ByteArrayConverter.byteArrayToBitmap(R.warehouseIcon);
            base.Width = 0.03;
            base.Height = 0.03;
            this.Warehouse = warehouse;
        }
    }
}