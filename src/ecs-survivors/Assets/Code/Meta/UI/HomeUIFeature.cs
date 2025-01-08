using Code.Infrastructure.Systems;
using Code.Meta.UI.GoldHolder.Systems;
using Code.Meta.UI.Shop.Systems;

namespace Code.Meta.UI
{
    public sealed class HomeUIFeature : Feature
    {
        public HomeUIFeature(ISystemFactory systems)
        {
            systems.Create<InitializePurchasedItemsSystem>();
            
            systems.Create<RefreshGoldGainBoostSystem>();
            systems.Create<RefreshGoldSystem>();
        }
    }
}