using Gameplay.Player;
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
        [SerializeField] private PlayerMovement _playerMovement;
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterInfrastructure(builder);

            builder.RegisterComponent(_playerMovement).AsImplementedInterfaces();
        }

        private void RegisterInfrastructure(IContainerBuilder builder)
        {
            builder
                .Register<GameStartCountdown.GameStartCountdown>(Lifetime.Scoped)
                .AsImplementedInterfaces()
                .AsSelf();
            
            builder.RegisterComponent(_gameStartCountdownView);
            builder.RegisterEntryPoint<GameStartCountdownAdapter>().AsSelf();
            
            builder.RegisterEntryPoint<GameManager>().AsSelf();

            builder.RegisterEntryPoint<GameEventsObserver>().AsSelf();
            
            builder.RegisterComponent(_updateObserver);
        }
    }
}