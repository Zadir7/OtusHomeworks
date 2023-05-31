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
        [SerializeField] private LevelBackground levelBackground;
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private EnemySpawner enemySpawner;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterGameManager(builder);
            RegisterInputManagers(builder);

            RegisterGameBackground(builder);

            RegisterBulletSystems(builder);

            RegisterCharacterControllers(builder);

            RegisterEnemySystems(builder);
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
            builder.RegisterComponent(levelBackground);
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

        private void RegisterEnemySystems(IContainerBuilder builder)
        {
            builder.RegisterComponent(enemyPool);

            builder.RegisterComponent(enemySpawner);

            builder
                .Register<EnemyObserver>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}