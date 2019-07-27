using System;

namespace Redux.Models
{
    public class Item
    {
        public string Text { get; set; }
        public int Quantity { get; set; }
        public ItemCategory Category { get; set; }
    }
}