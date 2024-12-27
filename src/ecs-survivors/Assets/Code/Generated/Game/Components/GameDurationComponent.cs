//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDuration;

    public static Entitas.IMatcher<GameEntity> Duration {
        get {
            if (_matcherDuration == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Duration);
                matcher.componentNames = GameComponentsLookup.componentNames;
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
public partial class GameEntity {

    public Code.Gameplay.Features.Statuses.StatusComponents.Duration duration { get { return (Code.Gameplay.Features.Statuses.StatusComponents.Duration)GetComponent(GameComponentsLookup.Duration); } }
    public float Duration { get { return duration.Value; } }
    public bool hasDuration { get { return HasComponent(GameComponentsLookup.Duration); } }

    public GameEntity AddDuration(float newValue) {
        var index = GameComponentsLookup.Duration;
        var component = (Code.Gameplay.Features.Statuses.StatusComponents.Duration)CreateComponent(index, typeof(Code.Gameplay.Features.Statuses.StatusComponents.Duration));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDuration(float newValue) {
        var index = GameComponentsLookup.Duration;
        var component = (Code.Gameplay.Features.Statuses.StatusComponents.Duration)CreateComponent(index, typeof(Code.Gameplay.Features.Statuses.StatusComponents.Duration));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDuration() {
        RemoveComponent(GameComponentsLookup.Duration);
        return this;
    }
}
