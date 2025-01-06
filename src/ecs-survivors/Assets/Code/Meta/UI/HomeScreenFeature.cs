using Code.Common.Destruct;
using Code.Infrastructure.Systems;
using Code.Meta.Features.Simulation;

namespace Code.Meta.UI
{
    public class HomeScreenFeature: Feature
    {
        public HomeScreenFeature(ISystemFactory systems)
        {
            Add(systems.Create<EmitTickSystem>());

            Add(systems.Create<SimulationFeature>());
            

            Add(systems.Create<CleanupTickSystem>());
            Add(systems.Create<ProcessDestructedFeature>());
            
        }
    }
}