using Infrastructure.GameEventObservers;
using Infrastructure.GameStartCountdown;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure
{
    public class AppLifeTimeScope : LifetimeScope
    {
        [SerializeField] private GameStartCountdownView _gameStartCountdownView;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameManager>();

            builder
                .Register<GameStartCountdown.GameStartCountdown>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.RegisterComponent(_gameStartCountdownView);
            builder.Register<GameStartCountdownAdapter>(Lifetime.Singleton);
            
            builder.Register<GameEventsObserver>(Lifetime.Singleton);
        }
    }
}