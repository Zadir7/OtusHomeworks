using System;
using Infrastructure.GameEventListeners;

namespace Infrastructure.GameStartCountdown
{
    public sealed class GameStartCountdown : IUpdateListener
    {
        public event Action CountdownStarted = () => { };
        public event Action CountdownFinished = () => { };
        public event Action<float> CountdownTimeChanged = _ => { };

        private float _countdownTime = 0.0f;

        public void StartCountdown()
        {
            _countdownTime = 3.0f;
            CountdownStarted.Invoke();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_countdownTime <= 0.0f) return;

            _countdownTime -= deltaTime;
            if (_countdownTime <= 0.0f)
            {
                CountdownFinished.Invoke();
                return;
            }
            CountdownTimeChanged.Invoke(_countdownTime);
        }
    }
}