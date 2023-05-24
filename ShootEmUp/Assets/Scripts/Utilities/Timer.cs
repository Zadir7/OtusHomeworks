using System;

namespace Utilities
{
    public class Timer
    {
        public event Action OnExpire;
        
        private readonly float countdown;
        private float timeLeft;

        public Timer(float countdown)
        {
            
        }

        public void Update(float deltaTime)
        {
            this.timeLeft -= deltaTime;
            if (this.timeLeft <= 0.0f)
            {
                OnExpire?.Invoke();
                this.timeLeft += this.countdown;
            }
        }

        public void Reset()
        {
            this.timeLeft = this.countdown;
        }
    }
}