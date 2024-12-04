using Code.Infrastructure.View.Factory;
using Entitas;

namespace Code.Infrastructure.View.Systems
{
    public class BindEntityViewFromPrefabSystem : IExecuteSystem
    {
        private readonly IEntityViewFactory _entityViewFactory;
        private readonly IGroup<GameEntity> _entities;

        public BindEntityViewFromPrefabSystem(GameContext game, IEntityViewFactory entityViewFactory)
        {
            _entityViewFactory = entityViewFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ViewPrefab,
                    GameMatcher.View));
        }

        public void Execute()
        {
            foreach (GameEntity entity  in _entities )
            {
                _entityViewFactory.CreateViewForEntityFromPrefab(entity);
            }
        }
    }
}