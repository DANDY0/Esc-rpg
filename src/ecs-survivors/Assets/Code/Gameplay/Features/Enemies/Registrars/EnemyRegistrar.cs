using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
  public class EnemyRegistrar : EntityComponentRegistrar
  {
    public float Speed = 1;
    
    public override void RegisterComponents()
    {
      Entity
        .AddEnemyTypeId(EnemyTypeId.Goblin)
        .AddWorldPosition(transform.position)
        .AddDirection(Vector2.zero)
        .AddSpeed(Speed)
        .With(x => x.isEnemy = true)
        .With(x => x.isTurnedAlongDirection = true)
        ;
    }

    public override void UnregisterComponents()
    {
      
    }
  }
}