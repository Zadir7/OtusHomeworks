using System;
using VContainer.Unity;

namespace Gameplay.Player
{
    public sealed class PlayerCollisionObserver : 
        IStartable,
        IDisposable
    {
        private readonly PlayerView _playerView;

        public event Action PlayerCollidedAnObstacle = () => { };

        public PlayerCollisionObserver(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public void Start()
        {
            _playerView.Collided += OnPlayerCollision;
        }

        public void Dispose()
        {
            _playerView.Collided -= OnPlayerCollision;
        }

        private void OnPlayerCollision()
        {
            PlayerCollidedAnObstacle.Invoke();
        }
    }
}