﻿using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifiers;

        public EnemyFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }
        
        public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
        {
            switch (typeId)
            {
                case EnemyTypeId.Goblin:
                    return CreateGoblin(at);
            }

            throw new Exception($"Enemy with type id {typeId} does not exist");
        }

        private GameEntity CreateGoblin(Vector2 at)
        {
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddEnemyTypeId(EnemyTypeId.Goblin)
                    .AddWorldPosition(at)
                    .AddDirection(Vector2.zero)
                    .AddSpeed(1)
                    .AddCurrentHP(3)
                    .AddMaxHP(3)
                    .AddDamage(1)
                    .AddTargetsBuffer(new List<int>(1))
                    .AddRadius(0.3f)
                    .AddCollectTargetsInterval(0.5f)
                    .AddCollectTargetsTimer(0)
                    .AddLayerMask(CollisionLayer.Hero.AsMask())
                    .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue")
                    .With(x => x.isEnemy = true)
                    .With(x => x.isTurnedAlongDirection = true)
                    .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}