using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
    public class CollectTargetsFeature: Feature
    {
        public CollectTargetsFeature(ISystemFactory systems)
        {
            Add(systems.Create<CollectTargetsIntervalSystems>());
            Add(systems.Create<CastForTargetsSystem>());
            Add(systems.Create<CleanupTargetBuffersSystem>());
            
        }
    }
}