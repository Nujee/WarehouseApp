using WarehouseApp.Models;

namespace WarehouseApp.Services
{
    public static class DataGenerator
    {
        private static Random _random = new Random();

        public static List<Pallet> GeneratePallets(int count)
        {
            var pallets = new List<Pallet>();

            for (int i = 0; i < count; i++)
            {
                var pallet = new Pallet
                {
                    Id = $"Pallet_{i}",
                    Width = _random.Next(100, 200),
                    Height = _random.Next(100, 200),
                    Depth = _random.Next(100, 200),
                };

                int boxCount = _random.Next(1, 5);

                for (int j = 0; j < boxCount; j++)
                {
                    var box = new Box
                    {
                        Id = $"Box_{i}_{j}",
                        Width = _random.Next(25, 100),
                        Height = _random.Next(25, 100),
                        Depth = _random.Next(25,100),
                        Weight = _random.Next(1, 20),

                        ProductionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-_random.Next(100,365))),
                        ExpirationDate = _random.NextDouble() > 0.5
                            ? DateOnly.FromDateTime(DateTime.Now.AddDays(_random.Next(30, 180)))
                            : null
                    };

                    if (pallet.CanAddBox(box))
                        pallet.AddBox(box);
                }

                pallets.Add(pallet);
            }

            return pallets;
        }
    }
}
