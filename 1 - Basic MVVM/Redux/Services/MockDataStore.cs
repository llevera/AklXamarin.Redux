using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redux.Models;

namespace Redux.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        private List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item {Text = "Sausages", Quantity = 8, Category = ItemCategory.Meat},
                new Item {Text = "Apples", Quantity = 15, Category = ItemCategory.Fruit},
                new Item {Text = "Pears", Quantity = 10, Category = ItemCategory.Fruit},
                new Item {Text = "Potatoes", Quantity = 40, Category = ItemCategory.Vegetable},
                new Item {Text = "Eggplants", Quantity = 2, Category = ItemCategory.Vegetable},
                new Item {Text = "Celery", Quantity = 0, Category = ItemCategory.Vegetable},
            };

            foreach (var item in mockItems) items.Add(item);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}