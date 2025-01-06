//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherDuration;

    public static Entitas.IMatcher<MetaEntity> Duration {
        get {
            if (_matcherDuration == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.Duration);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherDuration = matcher;
            }

            return _matcherDuration;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaEntity {

    public Code.Meta.Features.Simulation.SimulationComponents.Duration duration { get { return (Code.Meta.Features.Simulation.SimulationComponents.Duration)GetComponent(MetaComponentsLookup.Duration); } }
    public float Duration { get { return duration.Value; } }
    public bool hasDuration { get { return HasComponent(MetaComponentsLookup.Duration); } }

    public MetaEntity AddDuration(float newValue) {
        var index = MetaComponentsLookup.Duration;
        var component = (Code.Meta.Features.Simulation.SimulationComponents.Duration)CreateComponent(index, typeof(Code.Meta.Features.Simulation.SimulationComponents.Duration));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public MetaEntity ReplaceDuration(float newValue) {
        var index = MetaComponentsLookup.Duration;
        var component = (Code.Meta.Features.Simulation.SimulationComponents.Duration)CreateComponent(index, typeof(Code.Meta.Features.Simulation.SimulationComponents.Duration));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public MetaEntity RemoveDuration() {
        RemoveComponent(MetaComponentsLookup.Duration);
        return this;
    }
}
