using System;
using System.Collections.Generic;
using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop.Service
{
    public interface IShopUIService
    {
        event Action ShopChanged;
        void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItems);
        List<ShopItemConfig> GetAvailableShopItems();
        void Cleanup();
    }
}