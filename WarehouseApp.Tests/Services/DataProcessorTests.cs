using FluentAssertions;
using WarehouseApp.Models;
using WarehouseApp.Services;

namespace WarehouseApp.Tests.Services
{
    public sealed class DataProcessorTests
    {
        [Fact]
        public void GetTop3PalletsByExpiration_ShouldPrintCorrectTop3()
        {
            var pallets = new List<Pallet>();

            for (int i = 0; i < 5; i++)
            {
                var pallet = new Pallet { Id = $"Pallet_{i}", Width = 100, Height = 100, Depth = 100 };
                pallet.TryAddBox(new Box
                {
                    Id = $"Box_{i}",
                    Width = 50,
                    Height = 50,
                    Depth = 50,
                    Weight = 10,
                    ExpirationDate = new DateOnly(2025, 1, 1).AddDays(i * 10)
                });
                pallets.Add(pallet);
            }

            var output = new StringWriter();
            Console.SetOut(output);

            DataProcessor.GetTop3PalletsByExpiration(pallets);

            var printed = output.ToString();
            printed.Should().Contain("Pallet_4");
            printed.Should().Contain("Pallet_3");
            printed.Should().Contain("Pallet_2");
        }
    }
}