using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessCore;

namespace UnitTests
{
    [TestClass]
    public class GildedRoseShould
    {
        [TestMethod]
        public void MatchAssignedItemName()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 0, Quality = 0 } };
            var sut = new GildedRose(items);

            // Act
            sut.UpdateQuality();

            // Assert
            Assert.AreEqual("Sulfuras", items[0].Name);
        }

        [TestMethod]
        public void NeverChangeQualityForSulfuras()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };

            // Act
            ProcessQuality(items, 30);

            // Assert
            Assert.AreEqual(80, items[0].Quality);
            Assert.AreEqual(0, items[0].SellIn);
        }

        [TestMethod]
        public void IncreaseQualityForAgedBrie()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };

            // Act
            ProcessQuality(items, 10);

            // Assert
            Assert.AreEqual(18, items[0].Quality);
            Assert.AreEqual(-8, items[0].SellIn);
        }

        [TestMethod]
        public void NeverHaveQualityHigherThan50()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };

            // Act
            ProcessQuality(items, 30);

            // Assert
            Assert.AreEqual(50, items[0].Quality);
            Assert.AreEqual(-28, items[0].SellIn);
        }

        [TestMethod]
        public void NeverHaveNegativeQuality()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };

            // Act
            ProcessQuality(items, 30);

            // Assert
            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(-20, items[0].SellIn);
        }

        [TestMethod]
        public void IncreaseQualityForBackstagePass()
        {
            // Arrange
            IList<Item> items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 12,
                    Quality = 0
                }
            };

            // Act
            ProcessQuality(items, 11);

            // Assert
            Assert.AreEqual(24, items[0].Quality);
            Assert.AreEqual(1, items[0].SellIn);
        }

        [TestMethod]
        public void HaveQualityZeroAfterConcert()
        {
            // Arrange
            IList<Item> items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 60
                }
            };

            // Act
            ProcessQuality(items, 25);

            // Assert
            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(-15, items[0].SellIn);
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeExceptionWhenSellInNegative()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Some Item", Quality = 25, SellIn = -2 } };

            // Act -> Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new GildedRose(items));
        }

        private void ProcessQuality(IList<Item> items, int days)
        {
            var sut = new GildedRose(items);

            for (var i = 1; i <= days; i++)
            {
                sut.UpdateQuality();
            }
        }
    }
}