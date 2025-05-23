using WarehouseApp.Services;

var pallets = DataGenerator.GeneratePallets(10);
DataProcessor.GroupByExpiration(pallets);
Console.WriteLine("\nTop-3 pallets by max expiration date:");
DataProcessor.GetTop3PalletsByExpiration(pallets);
