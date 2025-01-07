using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta.UI;
using Code.Meta.UI.GoldHolder.Service;

namespace Code.Infrastructure.States.GameStates
{
  public class HomeScreenState : IState, IUpdateable
  {
    private readonly ISystemFactory _systems;
    private readonly GameContext _game;
    private readonly IStorageUiService _storageUiService;
    private HomeScreenFeature _homeScreenFeature;

    public HomeScreenState( ISystemFactory systems, GameContext game, IStorageUiService storageUiService)
    {
      _systems = systems;
      _game = game;
      _storageUiService = storageUiService;
    }
    public void Enter()
    {
      _homeScreenFeature = _systems.Create<HomeScreenFeature>();
      _homeScreenFeature.Initialize();
    }

    public void Update()
    {
      _homeScreenFeature.Execute();
      _homeScreenFeature.Cleanup();
    }

    public void Exit()
    {
      _storageUiService.Cleanup();
      _homeScreenFeature.DeactivateReactiveSystems();
      _homeScreenFeature.ClearReactiveSystems();

      DestructEntities();
      
      _homeScreenFeature.Cleanup();
      _homeScreenFeature.TearDown();
      _homeScreenFeature = null;
    }

    private void DestructEntities()
    {
      foreach (var entity in _game.GetEntities()) 
        entity.isDestructed = true;
    }
  } 
}
