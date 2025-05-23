namespace WarehouseApp.Models
{
    public sealed class Box : BaseWarehouseItem
    {
        public required double Weight { get; init; }
        public DateOnly? ProductionDate { get; init; }
        public DateOnly? ExpirationDate { get; init; }

        public DateOnly CalculatedExpirationDate
        {
            get
            {
                if (ExpirationDate.HasValue)
                    return ExpirationDate.Value;

                if (ProductionDate.HasValue)
                    return ProductionDate.Value.AddDays(100);

                throw new InvalidOperationException("Cannot calculate expiration date: " +
                    "both ExpirationDate and ProductionDate are null.");
            }
        }
    }
}
