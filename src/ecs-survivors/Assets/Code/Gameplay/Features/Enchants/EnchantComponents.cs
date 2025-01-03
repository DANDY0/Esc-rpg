﻿using Code.Gameplay.Common.Visuals.Enchants;
using Entitas;

namespace Code.Gameplay.Features.Enchants
{
    public class EnchantComponents
    {
        [Game] public class EnchantTypeIdComponent : IComponent { public EnchantTypeId Value; }
        [Game] public class PoisonEnchant : IComponent {  }
        [Game] public class EnchantVisualsComponent : IComponent { public IEnchantVisuals Value;
        }
    }
}