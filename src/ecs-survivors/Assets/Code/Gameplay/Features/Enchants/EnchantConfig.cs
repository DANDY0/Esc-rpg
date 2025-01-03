using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants
{
    [CreateAssetMenu(menuName = "ECS survivors/Enchant Config", fileName = "enchantConfig")]
    public class EnchantConfig: ScriptableObject
    {
        public EnchantTypeId TypeId;
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    }
}