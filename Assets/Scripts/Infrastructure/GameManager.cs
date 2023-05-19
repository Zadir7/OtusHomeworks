using System;
using Gameplay.Player;
using Infrastructure.PauseGameButton;
using VContainer.Unity;

namespace Infrastructure
{
    public sealed class GameManager : IStartable, IDisposable
    {
        public event Action GameStarted = () => { };
        public event Action GamePaused = () => { };
        public event Action GameResumed = () => { };
        public event Action GameFinished = () => { };

        private readonly GameStartCountdown.GameStartCountdown _gameStartCountdown;
        private readonly PauseGameButtonListener _pauseGameButtonListener;
        private readonly PlayerCollisionObserver _playerCollisionObserver;

        private GameState _gameState;

        public GameManager(
            GameStartCountdown.GameStartCountdown gameStartCountdown, 
            PauseGameButtonListener pauseGameButtonListener,
            PlayerCollisionObserver playerCollisionObserver)
        {
            _gameStartCountdown = gameStartCountdown;
            _pauseGameButtonListener = pauseGameButtonListener;
            _playerCollisionObserver = playerCollisionObserver;
        }
        
        public void Start()
        {
            _gameState = GameState.NotStarted;
            _gameStartCountdown.StartCountdown();
            
            _gameStartCountdown.CountdownFinished += StartGame;
            _pauseGameButtonListener.ButtonPressed += HandlePauseButtonClick;
            _playerCollisionObserver.PlayerCollidedAnObstacle += FinishGame;
        }
        
        public void Dispose()
        {
            _gameStartCountdown.CountdownFinished -= StartGame;
            _pauseGameButtonListener.ButtonPressed -= HandlePauseButtonClick;
            _playerCollisionObserver.PlayerCollidedAnObstacle -= FinishGame;
        }

        private void StartGame()
        {
            if (_gameState != GameState.NotStarted) return;
            _gameState = GameState.InProgress;
            GameStarted.Invoke();
        }

        private void PauseGame()
        {
            if (_gameState != GameState.InProgress) return;
            _gameState = GameState.Paused;
            GamePaused.Invoke();
        }

        private void ResumeGame()
        {
            if (_gameState != GameState.Paused) return;
            _gameState = GameState.InProgress;
            GameResumed.Invoke();
        }

        private void FinishGame()
        {
            if (_gameState != GameState.InProgress) return;
            _gameState = GameState.Finished;
            GameFinished.Invoke();
        }

        private void HandlePauseButtonClick()
        {
            switch (_gameState)
            {
                case GameState.Paused:
                    ResumeGame();
                    return;
                case GameState.InProgress:
                    PauseGame();
                    return;
                default: return;
            }
        }
    }
}