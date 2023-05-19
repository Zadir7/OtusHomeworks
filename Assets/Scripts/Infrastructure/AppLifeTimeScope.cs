using Gameplay.Camera;
using Gameplay.Player;
using Infrastructure.GameEventObservers;
using Infrastructure.GameStartCountdown;
using Infrastructure.PauseGameButton;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure
{
    public class AppLifeTimeScope : LifetimeScope
    {
        [SerializeField] private GameStartCountdownView _gameStartCountdownView;
        [SerializeField] private UpdateObserver _updateObserver;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private CameraView _cameraView;
        [SerializeField] private PauseGameButtonView _pauseGameButtonView;
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterInfrastructure(builder);

            RegisterPlayer(builder);
            RegisterCamera(builder);
        }

        private void RegisterInfrastructure(IContainerBuilder builder)
        {
            RegisterPauseButton(builder);

            RegisterGameStartCountdown(builder);

            builder.RegisterEntryPoint<GameManager>().AsSelf();

            builder.RegisterEntryPoint<GameEventsObserver>().AsSelf();
            
            builder.RegisterComponent(_updateObserver);
        }

        private void RegisterPauseButton(IContainerBuilder builder)
        {
            builder.RegisterComponent(_pauseGameButtonView);
            builder.RegisterEntryPoint<PauseGameButtonListener>().AsSelf();
        }

        private void RegisterGameStartCountdown(IContainerBuilder builder)
        {
            builder
                .Register<GameStartCountdown.GameStartCountdown>(Lifetime.Scoped)
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterComponent(_gameStartCountdownView);
            builder.RegisterEntryPoint<GameStartCountdownAdapter>().AsSelf();
        }

        private void RegisterPlayer(IContainerBuilder builder)
        {
            builder.RegisterComponent(_playerView);
            builder.RegisterEntryPoint<PlayerMovement>();
        }

        private void RegisterCamera(IContainerBuilder builder)
        {
            builder.RegisterComponent(_cameraView);
            builder.RegisterEntryPoint<CameraPlayerFollower>();
        }
    }
}