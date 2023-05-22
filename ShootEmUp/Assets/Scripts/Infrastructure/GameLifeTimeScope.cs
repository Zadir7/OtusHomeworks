using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private CharacterView characterView;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig characterBulletConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .Register<GameManager>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            
            builder
                .Register<InputManager>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterComponent(bulletSystem);
            builder.RegisterComponent(characterBulletConfig);
            
            
            RegisterCharacterControllers(builder);
        }

        private void RegisterCharacterControllers(IContainerBuilder builder)
        {
            builder
                .RegisterComponent(characterView)
                .AsSelf();

            builder
                .Register<CharacterController>(Lifetime.Singleton)
                .AsImplementedInterfaces();
            
            builder
                .Register<CharacterFireController>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .WithParameter("bulletConfig", characterBulletConfig);
            
            builder
                .Register<CharacterMoveController>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}