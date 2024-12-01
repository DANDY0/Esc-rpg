using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Common.Destruct.Systems
{
    public class SelfDestructTimerSystem: IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _entities;

        public SelfDestructTimerSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _entities = game.GetGroup(GameMatcher.SelfDestructTimer);
        }
        
        public void Execute()
        {
            foreach (var entity in _entities)
            {
                if (entity.SelfDestructTimer > 0)
                    entity.ReplaceSelfDestructTimer(entity.SelfDestructTimer - _time.DeltaTime);
                else
                {
                    entity.RemoveSelfDestructTimer();
                    entity.isDestructed = true;
                }
            }
        }
    }
}