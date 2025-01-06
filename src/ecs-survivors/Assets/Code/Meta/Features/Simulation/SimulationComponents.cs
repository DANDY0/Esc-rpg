using Entitas;

namespace Code.Meta.Features.Simulation
{
    public class SimulationComponents
    {
        [Meta] public class Tick : IComponent { public float  Value; }
        [Meta] public class GoldGainBoost : IComponent { public float  Value; }
        [Meta] public class Duration : IComponent { public float  Value; }

    }
} 