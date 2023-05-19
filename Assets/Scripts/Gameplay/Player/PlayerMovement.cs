using Infrastructure.GameEventListeners;
using UnityEngine;
using VContainer.Unity;

namespace Gameplay.Player
{
    public class PlayerMovement : 
        IStartable,
        IGameStartListener, 
        IGamePauseListener, 
        IGameResumeListener, 
        IGameFinishListener,
        IUpdateListener
    {
        private readonly PlayerView _playerView;
        
        private bool _enabled;
        
        private const float Speed = 2.0f;

        public PlayerMovement(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public void Start()
        {
            _enabled = false;
        }

        public void OnGameStart()
        {
            _enabled = true;
        }

        public void OnGamePause()
        {
            _enabled = false;
        }

        public void OnGameResume()
        {
            _enabled = true;
        }

        public void OnGameFinish()
        {
            _enabled = false;
        }

        public void OnUpdate(float deltaTime)
        {
            if (!_enabled) return;
            
            Vector3 direction = Vector3.forward;
            _playerView.transform.position += direction * (Speed * deltaTime);
        }
    }
}