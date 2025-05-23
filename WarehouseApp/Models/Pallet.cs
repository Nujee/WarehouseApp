namespace WarehouseApp.Models
{
    public sealed class Pallet : BaseWarehouseItem
    {
        private readonly List<Box> _boxes = [];

        public IReadOnlyList<Box> Boxes => 
            _boxes.AsReadOnly();

        public double Weight => 
            30 + _boxes.Sum(box => box.Weight);

        public override double Volume => 
            base.Volume + _boxes.Sum(box => box.Volume);

        public DateOnly? ExpirationDate => _boxes.Count != 0
            ? _boxes.Min(box => box.CalculatedExpirationDate)
            : null;

        public bool TryAddBox(Box box)
        {
            ArgumentNullException.ThrowIfNull(box);

            bool isValidWidth = (box.Width <= this.Width);
            bool isValidDepth = (box.Depth <= this.Depth);

            if (isValidWidth && isValidDepth)
            {
                _boxes.Add(box);
                return true;
            }

            return false;
        }
    }
}
