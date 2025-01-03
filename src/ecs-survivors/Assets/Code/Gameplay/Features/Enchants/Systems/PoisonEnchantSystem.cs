﻿using System.Collections.Generic;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public class PoisonEnchantSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<GameEntity> _enchants;
        private readonly IGroup<GameEntity> _armaments;
        private List<GameEntity> _buffer = new(32);

        public PoisonEnchantSystem(GameContext contextParameter, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _enchants = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EnchantTypeId,
                    GameMatcher.ProducerId,
                    GameMatcher.PoisonEnchant));

            _armaments = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.ProducerId)
                .NoneOf(GameMatcher.PoisonEnchant));
        }

        public void Execute()
        {
            foreach (GameEntity enchant in _enchants)
            foreach (GameEntity armament in _armaments.GetEntities(_buffer))
            {
                if (enchant.ProducerId == armament.ProducerId)
                {
                    GetOrAddStatusSetups(armament)
                        .AddRange(_staticDataService.GetEnchantConfig(EnchantTypeId.PoisonArmaments).StatusSetups);
                    
                    armament.isPoisonEnchant = true;
                }
            }
        }

        private static List<StatusSetup> GetOrAddStatusSetups(GameEntity armament)
        {
            if (!armament.hasStatusSetups)
                armament.AddStatusSetups(new List<StatusSetup>());
            
            return armament.StatusSetups;
        }
    }
}