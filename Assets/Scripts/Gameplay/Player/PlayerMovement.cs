using Infrastructure.GameEventListeners;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour,
        IGameStartListener, 
        IGamePauseListener, 
        IGameResumeListener, 
        IGameFinishListener,
        IUpdateListener
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private float _speed;

        private void Awake()
        {
            this.enabled = false;
        }

        public void OnGameStart()
        {
            this.enabled = true;
        }

        public void OnGamePause()
        {
            this.enabled = false;
        }

        public void OnGameResume()
        {
            this.enabled = true;
        }

        public void OnGameFinish()
        {
            this.enabled = false;
        }

        public void OnUpdate(float deltaTime)
        {
            Vector3 direction = Vector3.forward;
            _playerView.transform.position += direction * (_speed * deltaTime);
        }
    }
}