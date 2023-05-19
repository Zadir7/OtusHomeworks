using System;
using VContainer.Unity;

namespace Infrastructure
{
    public class GameManager : IStartable, IDisposable
    {
        public event Action GameStarted = () => { };
        public event Action GamePaused = () => { };
        public event Action GameResumed = () => { };
        public event Action GameFinished = () => { };

        private readonly GameStartCountdown.GameStartCountdown _gameStartCountdown;
        
        private GameState _gameState;

        public GameManager(GameStartCountdown.GameStartCountdown gameStartCountdown)
        {
            _gameStartCountdown = gameStartCountdown;

            _gameStartCountdown.CountdownFinished += StartGame;
        }
        
        public void Dispose()
        {
            _gameStartCountdown.CountdownFinished -= StartGame;
        }

        public void Start()
        {
            _gameState = GameState.NotStarted;
            _gameStartCountdown.StartCountdown();
        }

        private void StartGame()
        {
            if (_gameState != GameState.NotStarted) return;
            GameStarted.Invoke();
        }

        private void PauseGame()
        {
            if (_gameState != GameState.InProgress) return;
            GamePaused.Invoke();
        }

        private void ResumeGame()
        {
            if (_gameState != GameState.Paused) return;
            GameResumed.Invoke();
        }

        private void FinishGame()
        {
            if (_gameState != GameState.InProgress) return;
            GameFinished.Invoke();
        }
    }
}