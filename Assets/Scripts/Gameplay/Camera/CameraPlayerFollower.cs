using System;
using Gameplay.Player;
using Infrastructure.GameEventListeners;
using UnityEngine;
using VContainer.Unity;

namespace Gameplay.Camera
{
    public class CameraPlayerFollower : 
        IGameStartListener,
        IGameFinishListener,
        ILateUpdateListener,
        IStartable, 
        IDisposable
    {
        private readonly Transform _playerViewTransform;
        private readonly Transform _cameraViewTransform;

        private Vector3 _offset;
        
        private bool _enabled;

        public CameraPlayerFollower(PlayerView playerView, CameraView cameraView)
        {
            _playerViewTransform = playerView.transform;
            _cameraViewTransform = cameraView.transform;
        }
        
        public void Start()
        {
            _offset = _cameraViewTransform.position - _playerViewTransform.position;
            _enabled = false;
        }

        public void Dispose()
        {
        }
        
        public void OnGameStart()
        {
            _enabled = true;
        }

        public void OnGameFinish()
        {
            _enabled = false;
        }
        
        public void OnLateUpdate(float _)
        {
            if (!_enabled) return;
            
            _cameraViewTransform.position = _playerViewTransform.position + _offset;
        }
    }
}