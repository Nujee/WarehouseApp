using FluentAssertions;
using WarehouseApp.Services;

namespace WarehouseApp.Tests.Services
{
    public sealed class DataGeneratorTests
    {
        [Fact]
        public void GeneratePallets_ShouldReturnRequestedCount()
        {
            var pallets = DataGenerator.GeneratePallets(5);
            pallets.Should().HaveCount(5);
        }

        [Fact]
        public void GeneratePallets_ShouldGenerateBoxesWithinPalletDimensions()
        {
            var pallets = DataGenerator.GeneratePallets(3);

            foreach (var pallet in pallets)
            {
                pallet.Boxes.Should().NotBeEmpty();

                foreach (var box in pallet.Boxes)
                {
                    box.Width.Should().Match(boxWidth => boxWidth <= pallet.Width);
                    box.Depth.Should().Match(boxDepth => boxDepth <= pallet.Depth);
                }
            }
        }

        [Fact]
        public void GeneratePallets_ShouldAssignValidDatesToBoxes()
        {
            var pallets = DataGenerator.GeneratePallets(3);

            foreach (var pallet in pallets)
            {
                foreach (var box in pallet.Boxes)
                {
                    var date = box.CalculatedExpirationDate;
                    date.Should().BeAfter(DateOnly.MinValue);
                }
            }
        }
    }
}