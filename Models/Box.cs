namespace WarehouseApp.Models
{
    public sealed class Box : BaseWarehouseItem
    {
        public double Weight { get; set; }
        public DateOnly? ProductionDate { get; set; }
        public DateOnly? ExpirationDate { get; set; }

        public DateOnly CalculatedExpirationDate
        {
            get
            {
                if (ExpirationDate.HasValue)
                {
                    return ExpirationDate.Value;
                }

                if (ProductionDate.HasValue)
                {
                    return ProductionDate.Value.AddDays(100);
                }

                throw new InvalidOperationException("Cannot calculate expiration date: " +
                    "both ExpirationDate and ProductionDate are null.");
            }
        }
    }
}
