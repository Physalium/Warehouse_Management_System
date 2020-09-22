namespace Warehouse_Management.ViewModel.MapItems
{
    using Warehouse_Management.Model;
    using Warehouse_Management.ViewModel.EntitiesVM;

    using R = Properties.Resources;

    internal class CustomerItem : BaseItem
    {
        public CustomerVM Customer { get; set; }

        public CustomerItem(double xPos, double yPos, CustomerVM customer) : base(xPos, yPos)
        {
            base.ItemImage = ByteArrayConverter.byteArrayToBitmap(R.customerIcon);
            base.Width = 0.03;
            base.Height = 0.03;
            this.Customer = customer;
        }
    }
}