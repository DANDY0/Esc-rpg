using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class SpriteRendererRegistrar : EntityComponentRegistrar
    {
        public SpriteRenderer SpriteRenderer;
      
        public override void RegisterComponents()
        {
            Entity
                .AddSpriteRenderer(SpriteRenderer);
        }

        public override void UnregisterComponents()
        {
            Entity
                .RemoveSpriteRenderer();
        }
    }
}