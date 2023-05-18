using System;
using System.Collections.Generic;
using Infrastructure.GameEventListeners;

namespace Infrastructure.GameEventObservers
{
    public class GameEventsObserver : IDisposable
    {
        private readonly GameManager _gameManager;
        
        private readonly IEnumerable<IGameStartListener> _gameStartListeners;
        private readonly IEnumerable<IGamePauseListener> _gamePauseListeners;
        private readonly IEnumerable<IGameResumeListener> _gameResumeListeners;
        private readonly IEnumerable<IGameFinishListener> _gameFinishListeners;
        

        public GameEventsObserver(
            GameManager gameManager,
            IEnumerable<IGameStartListener> gameStartListeners, 
            IEnumerable<IGamePauseListener> gamePauseListeners,
            IEnumerable<IGameResumeListener> gameResumeListeners,
            IEnumerable<IGameFinishListener> gameFinishListeners)
        {
            _gameManager = gameManager;
            _gameStartListeners = gameStartListeners;
            _gamePauseListeners = gamePauseListeners;
            _gameResumeListeners = gameResumeListeners;
            _gameFinishListeners = gameFinishListeners;

            _gameManager.GameStarted += OnGameStart;
            _gameManager.GamePaused += OnGamePause;
            _gameManager.GameResumed += OnGameResume;
            _gameManager.GameFinished += OnGameFinish;
        }

        public void Dispose()
        {
            _gameManager.GameStarted -= OnGameStart;
            _gameManager.GamePaused -= OnGamePause;
            _gameManager.GameResumed -= OnGameResume;
            _gameManager.GameFinished -= OnGameFinish;
        }

        private void OnGameStart()
        {
            if (_gameStartListeners is null) return;
            
            foreach (var listener in _gameStartListeners)
            {
                if (listener is null) continue;
                listener.OnGameStart();
            }
        }
        
        private void OnGamePause()
        {
            if (_gamePauseListeners is null) return;
            
            foreach (var listener in _gamePauseListeners)
            {
                if (listener is null) continue;
                listener.OnGamePause();
            }
        }
        
        private void OnGameResume()
        {
            if (_gameResumeListeners is null) return;
            
            foreach (var listener in _gameResumeListeners)
            {
                if (listener is null) continue;
                listener.OnGameResume();
            }
        }
        
        private void OnGameFinish()
        {
            if (_gameFinishListeners is null) return;
            
            foreach (var listener in _gameFinishListeners)
            {
                if (listener is null) continue;
                listener.OnGameFinish();
            }
        }
    }
}