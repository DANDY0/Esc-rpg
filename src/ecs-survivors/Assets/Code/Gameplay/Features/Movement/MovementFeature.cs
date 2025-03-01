﻿using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;
using Unity.VisualScripting;

namespace Code.Gameplay.Features.Movement
{
  public class MovementFeature : Feature
  {
    public MovementFeature(ISystemFactory systems)
    {
      Add(systems.Create<DirectionalDeltaMoveSystem>());
      Add(systems.Create<TurnAlongDirectionSystem>());
      Add(systems.Create<UpdateTransformPositionSystem>());
    }
  }
}