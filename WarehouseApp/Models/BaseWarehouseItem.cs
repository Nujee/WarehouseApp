namespace WarehouseApp.Models
{
    public abstract class BaseWarehouseItem
    {
        public required string Id { get; init; }
        public required double Width { get; init; }
        public required double Height { get; init; }
        public required double Depth { get; init; }

        public virtual double Volume => Width * Height * Depth;
    }
}
