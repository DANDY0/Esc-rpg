using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Indexing;
using Entitas;
using Zenject;

namespace Code.Common.EntityIndices
{
    public class GameEntityIndeces: IInitializable
    {
        private readonly GameContext _game;
        public const string StatusesOfType = "StatusesOfType";

        public GameEntityIndeces(GameContext game)
        {
            _game = game;
        }
        
        public void Initialize()
        {
            _game.AddEntityIndex(new EntityIndex<GameEntity, StatusKey>(
                StatusesOfType,
                _game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.StatusTypeId,
                GameMatcher.TargetId,
                    GameMatcher.Status,
                    GameMatcher.Duration,
                    GameMatcher.TimeLeft)),
                GetTargetStatusKey,
                new StatusKeyEqualityComparer()
                 ));    
        }

        private StatusKey GetTargetStatusKey(GameEntity entity, IComponent component)
        {
            return new StatusKey(
                (component as EffectComponents.TargetId)?.Value ?? entity.TargetId,
                (component as StatusComponents.StatusTypeIdComponent)?.Value ?? entity.StatusTypeId);
        }
    }

    public static class ContextIndicesExtensions
    {
        public static HashSet<GameEntity> TargetStatusesOfType(this GameContext context, StatusTypeId statusTypeId,
            int targetId)
        {
            return ((EntityIndex<GameEntity, StatusKey>)context.GetEntityIndex(GameEntityIndeces.StatusesOfType))
                .GetEntities(new StatusKey(targetId, statusTypeId));
        }
    }
}