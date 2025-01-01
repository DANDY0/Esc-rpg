using System.Collections.Generic;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.System
{
    public class GarlicAuraAbilitySystem : IExecuteSystem
    {
        private readonly IArmamentsFactory _armamentsFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private List<GameEntity> _buffer = new(32);

        public GarlicAuraAbilitySystem(GameContext contextParameter, IArmamentsFactory armamentsFactory)
        {
            _armamentsFactory = armamentsFactory;
            _abilities = contextParameter.GetGroup(GameMatcher
                .AllOf(GameMatcher.GarlicAuraAbility)
                .NoneOf(GameMatcher.Active)    
            );
            
            _heroes = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Hero)    
            );

        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            foreach (GameEntity hero in _heroes)
            {
                _armamentsFactory.CreteEffectAura(AbilityId.GarlicAura, hero.Id, 1);

                ability.isActive = true;
            }
        }
    }
}