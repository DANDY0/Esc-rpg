using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.System
{
    public class VegetableBoltAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentsFactory _armamentsFactory;
        private List<GameEntity> _buffer = new(32);
        
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;

        public VegetableBoltAbilitySystem(GameContext game, IStaticDataService staticDataService, IArmamentsFactory armamentsFactory)
        {
            _staticDataService = staticDataService;
            _armamentsFactory = armamentsFactory;
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.VegetableBoltAbility,
                    GameMatcher.CooldownUp));

            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition));
            
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.WorldPosition));

        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            foreach (GameEntity hero in _heroes)
            {
                if(_enemies.count <= 0 )
                    continue;
                
                _armamentsFactory
                    .CreateVegetableBolt(1, hero.WorldPosition)
                    .ReplaceDirection((FirstAvailableTarget().WorldPosition - hero.WorldPosition).normalized)
                    .AddProducerId(hero.Id)
                    .With(x => x.isMoving = true);
                
                ability.PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, 1).Cooldown);
            }
            
            
        }

        private GameEntity FirstAvailableTarget()
        {
            return _enemies.AsEnumerable().First();
        }
    }
}