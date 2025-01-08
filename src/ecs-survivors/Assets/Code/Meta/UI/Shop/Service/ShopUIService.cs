﻿using System;
using System.Collections.Generic;
using Code.Gameplay.StaticData;
using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop.Service
{
    public class ShopUIService : IShopUIService
    {
        private List<ShopItemId> _purchasedItems = new();
        private Dictionary<ShopItemId, ShopItemConfig> _availableItems = new();
        private readonly IStaticDataService _staticData;

        public event Action ShopChanged;
        
        public ShopUIService(IStaticDataService staticData) 
            => _staticData = staticData;

        public void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItems)
        {
            _purchasedItems.AddRange(purchasedItems);

            RefreshAvailableItems();
        }

        public List<ShopItemConfig> GetAvailableShopItems() 
            => new(_availableItems.Values);

        public void Cleanup()
        {
              _purchasedItems.Clear();
              _availableItems.Clear();

              ShopChanged = null;
        }
        
        
        private void RefreshAvailableItems()
        {
            foreach (var itemConfig in _staticData.GetShopItemConfigs())
            {
                if(!_purchasedItems.Contains(itemConfig.ShopItemId))
                    _availableItems.Add(itemConfig.ShopItemId, itemConfig);
            }
            
            ShopChanged?.Invoke();
        }
    }
}