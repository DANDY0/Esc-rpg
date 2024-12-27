﻿using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.Statuses.StatusVisual
{
    public class ApplyPoisonVisualsSystem : ReactiveSystem<GameEntity>
    {
        public ApplyPoisonVisualsSystem(GameContext game) : base(game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
            => context.CreateCollector(GameMatcher.Poison.Added());

        protected override bool Filter(GameEntity entity) 
            => entity.isStatus && entity.isPoison;

        protected override void Execute(List<GameEntity> statuses)
        {
            foreach (GameEntity status in statuses)
            {
                var target = status.Target();
                if (target is { hasStatusVisuals: true }) 
                    target.StatusVisuals.ApplyPoison();
            }
        }
    }
}