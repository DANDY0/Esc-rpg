﻿using Code.Gameplay.Features.Loot.Systems;
using Code.Infrastructure.Systems;
using Unity.VisualScripting;

namespace Code.Gameplay.Features.Loot
{
    public class LootingFeature: Feature
    {
        public LootingFeature(ISystemFactory systems)
        {
            Add(systems.Create<CastForPullablesSystem>());
            
            Add(systems.Create<PullTowardsHeroSystem>());
            Add(systems.Create<CollectWhenNearSystem>());
            
            Add(systems.Create<CollectExperienceSystem>());
            Add(systems.Create<CollectEffectItemSystem>());
            Add(systems.Create<CollectStatusItemSystem>());

            
            
            Add(systems.Create<CleanupCollected>());
        }   
    }
}