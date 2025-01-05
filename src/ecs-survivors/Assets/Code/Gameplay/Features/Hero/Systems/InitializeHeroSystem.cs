using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Hero.Registrars;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class InitializeHeroSystem : IInitializeSystem
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IAbilityFactory _abilityFactory;
        private readonly IStatusApplier _statusApplier;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider, IAbilityFactory abilityFactory
        ,IStatusApplier statusApplier, IAbilityUpgradeService abilityUpgradeService)
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
            _abilityFactory = abilityFactory;
            _statusApplier = statusApplier;
            _abilityUpgradeService = abilityUpgradeService;
        }

        public void Initialize()
        {
            var hero = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
  
            _abilityUpgradeService.InitializeAbility(AbilityId.VegetableBolt);
            
            /*_abilityFactory.CreateVegetableBoltAbility(1);
            _abilityFactory.CreateOrbitingMushroomAbility(1);
            _abilityFactory.CreateGarlicAuraAbility();

            /*_statusApplier.ApplyStatus(new StatusSetup
            {
                StatusTypeId = StatusTypeId.PoisonEnchant,
                Duration = 10
            }, hero.Id, hero.Id);#1#
            
            _statusApplier.ApplyStatus(new StatusSetup
            {
                StatusTypeId = StatusTypeId.ExplosiveEnchant,
                Duration = 20
            }, hero.Id, hero.Id);*/
        }
    }
}