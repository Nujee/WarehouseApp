using WarehouseApp.Models;

namespace WarehouseApp.Services
{
    public static class DataProcessor
    {
        public static void GroupByExpiration(List<Pallet> pallets)
        {
            var groupedByExpiration = pallets
                .Where(pallet => pallet.Boxes.Count > 0)
                .GroupBy(pallet => pallet.ExpirationDate)
                .OrderBy(group => group.Key)
                .ToList();

            foreach (var group in groupedByExpiration)
            {
                Console.WriteLine($"Group with expiration date: {group.Key}");
                var sortedPallets = group
                    .OrderBy(pallet => pallet.Weight)
                    .ToList();

                foreach (var pallet in sortedPallets) 
                { 
                    Console.WriteLine($"{pallet.Id}, weight: {pallet.Weight} kg, volume: {pallet.Volume / 1_000_000} m^3");
                }
            }
        }

        public static void GetTop3PalletsByExpiration(List<Pallet> pallets)
        {
            var topPallets = pallets
                .Where(pallet => pallet.Boxes.Count > 0)
                .OrderByDescending(pallet => pallet.ExpirationDate)
                .ThenBy(pallet => pallet.Volume)
                .Take(3)
                .ToList();

            foreach (var pallet in topPallets)
            {
                Console.WriteLine($"{pallet.Id}, expiration date: {pallet.ExpirationDate}, volume: {pallet.Volume / 1_000_000} m^3");
            }
        }
    }
}
