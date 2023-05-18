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
        [SerializeField] private UpdateObserver _updateObserver;
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .Register<GameStartCountdown.GameStartCountdown>(Lifetime.Singleton)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.RegisterInstance<GameStartCountdownView>(_gameStartCountdownView);
            builder.Register<GameStartCountdownAdapter>(Lifetime.Singleton);
            
            builder.RegisterEntryPoint<GameManager>();
            
            builder.Register<GameEventsObserver>(Lifetime.Singleton);
            builder.RegisterInstance<UpdateObserver>(_updateObserver);
        }
    }
}