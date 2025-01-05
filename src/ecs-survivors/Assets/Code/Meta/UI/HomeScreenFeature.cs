using Code.Common.Destruct;
using Code.Infrastructure.Systems;

namespace Code.Meta.UI
{
    public class HomeScreenFeature: Feature
    {
        public HomeScreenFeature(ISystemFactory systems)
        {
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}