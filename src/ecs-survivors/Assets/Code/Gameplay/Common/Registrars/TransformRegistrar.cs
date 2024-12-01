using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class TransformRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity
                .AddTransform(transform);
        }

        public override void UnregisterComponents()
        {
            Entity
                .RemoveTransform();
        }
    }
}