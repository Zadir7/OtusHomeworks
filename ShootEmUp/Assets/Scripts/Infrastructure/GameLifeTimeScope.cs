using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private CharacterView characterView;
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private LevelBackgroundConfig levelBackgroundConfig;
        [SerializeField] private LevelBackgroundView levelBackground;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterGameManager(builder);
            RegisterInputManagers(builder);

            RegisterGameBackground(builder);

            RegisterBulletSystems(builder);

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

        private void RegisterInputManagers(IContainerBuilder builder)
        {
            builder
                .Register<HorizontalInputManager>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.Register<FireInputManager>(Lifetime.Singleton)
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

        private void RegisterBulletSystems(IContainerBuilder builder)
        {
            builder.RegisterComponent(bulletPool);
            builder.RegisterComponent(bulletSpawner);
            builder.RegisterComponent(levelBounds);

            builder.Register<BulletTracker>(Lifetime.Singleton)
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
                .AsImplementedInterfaces();
            
            builder
                .Register<CharacterMoveController>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}