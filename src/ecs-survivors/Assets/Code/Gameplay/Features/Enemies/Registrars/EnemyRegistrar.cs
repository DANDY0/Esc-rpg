﻿using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
  public class EnemyRegistrar : EntityComponentRegistrar
  {
    public float HP = 3;
    public float Damage = 1;
    public float Speed = 1;
    
    public override void RegisterComponents()
    {
      Entity
        .AddEnemyTypeId(EnemyTypeId.Goblin)
        .AddWorldPosition(transform.position)
        .AddDirection(Vector2.zero)
        .AddSpeed(Speed)
        .AddCurrentHP(HP)
        .AddMaxHP(HP)
        .AddDamage(Damage)
        .AddTargetsBuffer(new List<int>(1))
        .AddRadius(0.3f)
        .AddCollectTargetsInterval(0.5f)
        .AddCollectTargetsTimer(0)
        .AddLayerMask(CollisionLayer.Hero.AsMask())
        .With(x => x.isEnemy = true)
        .With(x => x.isTurnedAlongDirection = true)
        ;
    }

    public override void UnregisterComponents()
    {
      
    }
  }
}