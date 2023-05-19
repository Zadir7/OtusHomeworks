using System;
using VContainer.Unity;

namespace UI.GameStartCountdown
{
    public sealed class GameStartCountdownAdapter : IStartable, IDisposable
    {
        private readonly GameStartCountdown _countdown;
        private readonly GameStartCountdownView _view;
        
        private const string Three = "3";
        private const string Two = "2";
        private const string One = "1";

        public GameStartCountdownAdapter(GameStartCountdown countdown, GameStartCountdownView view)
        {
            _countdown = countdown;
            _view = view;
        }
        
        public void Start()
        {
            _countdown.CountdownStarted += OnCountdownStarted;
            _countdown.CountdownTimeChanged += OnCountdown;
            _countdown.CountdownFinished += OnCountdownFinished;
        }

        public void Dispose()
        {
            _countdown.CountdownStarted -= OnCountdownStarted;
            _countdown.CountdownTimeChanged -= OnCountdown;
            _countdown.CountdownFinished -= OnCountdownFinished;
        }

        private void OnCountdownStarted()
        {
            _view.UpdateText(Three);
            _view.Enable();
        }

        private void OnCountdown(float timeLeft)
        {
            switch (timeLeft)
            {
                case <= 0.0f:
                    return;
                case <= 1.0f: 
                    _view.UpdateText(One); 
                    return;
                case <= 2.0f: 
                    _view.UpdateText(Two); 
                    return;
                case <= 3.0f:
                    _view.UpdateText(Three);
                    return;
                default: return;
            };
        }

        private void OnCountdownFinished()
        {
            _view.Disable();
        }
    }
}