using Code.Gameplay.Features.Enemies.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.LifeTime
{
    public sealed class DeathFeature: Feature
    {
        public DeathFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkDeadSystem>());
            Add(systems.Create<EnemyDeathSystem>());
            
            Add(systems.Create<FinalizeEnemyDeathProcessingSystem>());
        }
    }
}