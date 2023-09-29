using System;
using System.Collections.Generic;
namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public static string AgedBrie = "Aged Brie";
        public static string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        public static string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public static string Conjured = "Conjured";
        public static int MaximumQuality = 50;
        public GildedRose(IList<Item> Items) => this.Items = Items;
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateRegular(item);
                UpdateBackStage(item);
                UpdateAgedBrie(item);
                UpdateConjured(item);
                UpdateSulfuras(item);

            }
        }

        private void UpdateSulfuras(Item item)
        {
        }

        private void UpdateConjured(Item item)
        {
            if (IsConjured(item))
                EditSellInandQuality(item, -2);
        }
        private void UpdateAgedBrie(Item item)
        {
            if (IsAgedBrie(item))
                EditSellInandQuality(item, 1);
        }
        private void UpdateBackStage(Item item)
        {
            if (IsBackStage(item))
                EditSellInandQuality(item, GetValueForBack(item));
        }
        private void UpdateRegular(Item item)
        {
            if (IsRegular(item))
                EditSellInandQuality(item, -1);
        }
        private void EditSellInandQuality(Item item, int qualityValue)
        {
            item.SellIn--;
            if (qualityValue == 0)
                item.Quality = 0;
            item.Quality += qualityValue;
            if (item.SellIn < 0)
                item.Quality += qualityValue;
            item.Quality = Math.Clamp(item.Quality, 0, MaximumQuality);
        }
        private int GetValueForBack(Item item)
        {
            if (item.SellIn <= 0) return 0;
            if (item.SellIn < 6) return 3;
            if (item.SellIn < 11) return 2;
            return 1;
        }
        private static bool IsConjured(Item item) => item.Name == Conjured;
        private static bool IsRegular(Item item) =>
            !(IsAgedBrie(item) || IsBackStage(item) || IsSulfuras(item) || IsConjured(item));
        private static bool IsSulfuras(Item item) => item.Name == Sulfuras;
        private static bool IsBackStage(Item item) => item.Name == BackstagePass;
        private static bool IsAgedBrie(Item item) => item.Name == AgedBrie;
    }
}