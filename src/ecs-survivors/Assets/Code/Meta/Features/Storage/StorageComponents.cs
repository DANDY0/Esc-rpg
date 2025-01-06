using Entitas;

namespace Code.Meta.Features.Storage
{
    public class StorageComponents
    {
        [Meta] public class Storage : IComponent {  }
        [Meta] public class Gold : IComponent { public float Value; }
        [Meta] public class GoldPerSecond : IComponent { public float Value; }

    }
}