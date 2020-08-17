namespace Warehouse_Management.Model
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int? WarehouseId { get; set; }
        public int? OrderId { get; set; }
        public int Weight { get; set; }
        public int Volume { get; set; }

        public virtual Order Order { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}