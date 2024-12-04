using Code.Infrastructure.View.Factory;
using Entitas;

namespace Code.Infrastructure.View.Systems
{
    public class BindEntityViewFromPathSystem : IExecuteSystem
    {
        private readonly IEntityViewFactory _entityViewFactory;
        private readonly IGroup<GameEntity> _entities;

        public BindEntityViewFromPathSystem(GameContext game, IEntityViewFactory entityViewFactory)
        {
            _entityViewFactory = entityViewFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ViewPath,
                    GameMatcher.View));
        }

        public void Execute()
        {
            foreach (GameEntity entity  in _entities )
            {
                _entityViewFactory.CreateViewForEntity(entity);
            }
        }
    }
}
