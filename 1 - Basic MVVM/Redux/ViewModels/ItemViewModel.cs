﻿using System;
using Redux.Models;
using Xamarin.Forms;

namespace Redux.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        private readonly Item _item;

        public ItemViewModel(Item item)
        {
            _item = item;
        }

        public string Text => _item.Text;

        public int Quantity => _item.Quantity;

        public Color TextColor
        {
            get
            {
                if (Quantity < 1)
                {
                    return Color.Gray;
                }

                switch (_item.Category)
                {
                    case ItemCategory.Fruit:
                        return Color.Orange;
                    case ItemCategory.Vegetable:
                        return Color.Green;
                    case ItemCategory.Meat:
                        return Color.Red;
                    default:
                        return Color.Gray;
                }
            }
        }

    }
}