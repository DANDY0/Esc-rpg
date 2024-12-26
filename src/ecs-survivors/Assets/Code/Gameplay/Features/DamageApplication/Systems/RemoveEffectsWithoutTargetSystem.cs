using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class RemoveEffectsWithoutTargetSystem: IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;

        public RemoveEffectsWithoutTargetSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Effect,
                GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity effect in _effects)
            {
                GameEntity target = effect.Target();
                
                if(target == null)
                    effect.Destroy();
            }
        }
    }
}