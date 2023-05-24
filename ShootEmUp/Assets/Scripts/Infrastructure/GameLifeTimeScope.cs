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
        [SerializeField] private LevelBackgroundConfig levelBackgroundConfig;
        [SerializeField] private LevelBackgroundView levelBackground;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterGameManager(builder);
            RegisterInputManager(builder);

            RegisterGameBackground(builder);

            builder.RegisterComponent(bulletSystem);
            builder.RegisterComponent(characterBulletConfig);

            RegisterCharacterControllers(builder);

            builder
                .Register<FinishGameController>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }

        private void RegisterGameManager(IContainerBuilder builder)
        {
            builder
                .Register<GameManager>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
        }

        private void RegisterInputManager(IContainerBuilder builder)
        {
            builder
                .Register<InputManager>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
        }

        private void RegisterGameBackground(IContainerBuilder builder)
        {
            builder
                .RegisterComponent(levelBackgroundConfig)
                .AsSelf();
            
            builder
                .RegisterComponent(levelBackground)
                .AsSelf();
            
            builder
                .Register<LevelBackground>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }

        private void RegisterCharacterControllers(IContainerBuilder builder)
        {
            builder
                .RegisterComponent(characterView)
                .AsSelf();

            builder
                .Register<CharacterController>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            
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