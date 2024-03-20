using System;
using Gameplay.Input;
using Infrastructure.GameEventListeners;
using UnityEngine;
using VContainer.Unity;

namespace Gameplay.Player
{
    public sealed class PlayerMovement : 
        IStartable,
        IDisposable,
        IGameStartListener, 
        IGamePauseListener, 
        IGameResumeListener, 
        IGameFinishListener,
        IUpdateListener
    {
        private readonly PlayerView _playerView;
        private readonly KeyboardInput _keyboardInput;

        private bool _enabled;
        
        private const float Speed = 2.0f;

        public PlayerMovement(PlayerView playerView, KeyboardInput keyboardInput)
        {
            _playerView = playerView;
            _keyboardInput = keyboardInput;
        }

        public void Start()
        {
            _enabled = false;
            _keyboardInput.LeftInput += MoveLeft;
            _keyboardInput.RightInput += MoveRight;
        }

        public void Dispose()
        {
            _keyboardInput.LeftInput -= MoveLeft;
            _keyboardInput.RightInput -= MoveRight;
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

        public void MoveLeft()
        {
            if (_playerView.PositionX > -0.1f) _playerView.MoveLeft();
        }
        
        public void MoveRight()
        {
            if (_playerView.PositionX < 0.1f) _playerView.MoveRight();
        }
    }
}