using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Statuses.StatusVisual;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
    public class StatusVisualsFeature: Feature
    {
        public StatusVisualsFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyPoisonVisualsSystem>());
            Add(systems.Create<UnApplyPoisonVisualsSystem>());
        }
    }
}