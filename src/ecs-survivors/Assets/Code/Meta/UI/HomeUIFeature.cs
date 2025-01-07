using Code.Infrastructure.Systems;
using Code.Meta.UI.GoldHolder.Systems;

namespace Code.Meta.UI
{
    public sealed class HomeUIFeature : Feature
    {
        public HomeUIFeature(ISystemFactory systems)
        {
            systems.Create<RefreshGoldSystem>();
        }
    }
}