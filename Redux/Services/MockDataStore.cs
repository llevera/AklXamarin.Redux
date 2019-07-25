using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redux.Models;

namespace Redux.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> _items;

        public MockDataStore()
        {
            _items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Text = "Sausages", Quantity=8, Category=ItemCategory.Meat},
                new Item { Text = "Apples", Quantity=15, Category=ItemCategory.Fruit},
                new Item { Text = "Pears", Quantity=10, Category=ItemCategory.Fruit},
                new Item { Text = "Potatoes", Quantity=40, Category=ItemCategory.Vegetable},
                new Item { Text = "Eggplants", Quantity=2, Category=ItemCategory.Vegetable},
                new Item { Text = "Celery", Quantity=0, Category=ItemCategory.Vegetable},
            };

            foreach (var item in mockItems)
            {
                _items.Add(item);
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(_items);
        }
    }
}