using FluentAssertions;
using WarehouseApp.Models;

namespace WarehouseApp.Tests.Models
{
    public sealed class PalletTests
    {
        [Fact]
        public void TryAddBox_ShouldAddBox_WhenDimensionsAreValid()
        {
            var pallet = new Pallet { Id = "Test", Width = 100, Height = 100, Depth = 100 };
            var box = new Box { Id = "Box1", Width = 90, Height = 90, Depth = 90, Weight = 5 };

            var result = pallet.TryAddBox(box);

            result.Should().BeTrue();
            pallet.Boxes.Should().Contain(box);
        }

        [Fact]
        public void TryAddBox_ShouldNotAddBox_WhenTooWide()
        {
            var pallet = new Pallet { Id = "Test", Width = 100, Height = 100, Depth = 100 };
            var box = new Box { Id = "Box1", Width = 110, Height = 90, Depth = 90, Weight = 5 };

            var result = pallet.TryAddBox(box);

            result.Should().BeFalse();
            pallet.Boxes.Should().BeEmpty();
        }

        [Fact]
        public void ExpirationDate_ShouldReturnEarliestBoxDate()
        {
            var pallet = new Pallet { Id = "Test", Width = 100, Height = 100, Depth = 100 };
            var early = new Box { Id = "Box1", Width = 90, Height = 90, Depth = 90, Weight = 5, ExpirationDate = new DateOnly(2025, 1, 1) };
            var late = new Box { Id = "Box2", Width = 90, Height = 90, Depth = 90, Weight = 5, ExpirationDate = new DateOnly(2025, 12, 31) };

            pallet.TryAddBox(early);
            pallet.TryAddBox(late);

            pallet.ExpirationDate.Should().Be(new DateOnly(2025, 1, 1));
        }
    }
}