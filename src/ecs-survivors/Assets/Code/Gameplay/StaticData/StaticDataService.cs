﻿using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<AbilityId,AbilityConfig> _abilityId;
    private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;
    private Dictionary<LootTypeId, LootConfig> _lootById;
    
    public void LoadAll()
    {
      LoadAbilities();
      LoadEnchants();
      LoadLoot();
    }

    public AbilityConfig GetAbilityConfig(AbilityId abilityId)
    {
      if (_abilityId.TryGetValue(abilityId, out AbilityConfig config))
        return config;
      throw new Exception($"Ability config for {abilityId} was not found");
    }
    
    public LootConfig GetLootConfig(LootTypeId lootTypeId)
    {
      if (_lootById.TryGetValue(lootTypeId, out LootConfig config))
        return config;
      throw new Exception($"Loot config for {lootTypeId} was not found");
    }

    public EnchantConfig GetEnchantConfig(EnchantTypeId typeId)
    {
      if (_enchantById.TryGetValue(typeId, out EnchantConfig config))
        return config;
      throw new Exception($"Enchant config for {typeId} was not found");
    }

    public AbilityLevel GetAbilityLevel(AbilityId abilityId, int level)
    {
      AbilityConfig config = GetAbilityConfig(abilityId);
      if (level > config.Levels.Count)
        level = config.Levels.Count;

      return config.Levels[level - 1]; 
    }

    private void LoadLoot()
    {
      _lootById = Resources
          .LoadAll<LootConfig>("Configs/Loot")
          .ToDictionary(x => x.LootTypeID, x => x);
      
    }

    public void LoadEnchants()
    {
      _enchantById = Resources
        .LoadAll<EnchantConfig>("Configs/Enchants")
        .ToDictionary(x=>x.TypeId, x => x); 
    }

    private void LoadAbilities()
    {
      _abilityId = Resources
        .LoadAll<AbilityConfig>("Configs/Abilities")
        .ToDictionary(x => x.AbilityId, x => x);
    }
  }
}