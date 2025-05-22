namespace WarehouseApp.Models
{
    public abstract class BaseWarehouseItem
    {
        public string Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }

        public virtual double Volume => Width * Height * Depth;
    }
}
