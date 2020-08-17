namespace Warehouse_Management.ViewModel.MapItems
{
    using Warehouse_Management.Model;
    using Warehouse_Management.ViewModel.EntitiesVM;

    using R = Properties.Resources;

    internal class WarehouseItem : BaseItem
    {
        public WarehouseVM Warehouse { get; set; }

        public WarehouseItem(double xPos, double yPos, WarehouseVM warehouse) : base(xPos, yPos)
        {
            base.ItemImage = ByteArrayConverter.byteArrayToBitmap(R.warehouseIcon);
            base.Width = 0.03;
            base.Height = 0.03;
            this.Warehouse = warehouse;
        }
    }
}