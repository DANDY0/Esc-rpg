using Code.Gameplay.Features.Abilities;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public interface IArmamentsFactory
    {
        GameEntity CreateVegetableBolt(int level, Vector3 at);
        GameEntity CreateMushroom(int level, Vector3 at, float phase);
        GameEntity CreteEffectAura(AbilityId parentAbilityId, int producerId, int level);
    }
}