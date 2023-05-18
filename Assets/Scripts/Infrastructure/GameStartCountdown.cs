using System;
using Infrastructure.GameEventListeners;

namespace Infrastructure
{
    public class GameStartCountdown : IUpdateListener
    {
        public event Action CountdownFinished = () => { };
        public event Action<float> CountdownTimeChanged = _ => { };

        private float _countdownTime;

        public void StartCountdown()
        {
            _countdownTime = 3.0f;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_countdownTime <= 0) return;

            _countdownTime -= deltaTime;
            if (_countdownTime <= 0)
            {
                CountdownFinished.Invoke();
                return;
            }
            CountdownTimeChanged.Invoke(_countdownTime);
        }
    }
}