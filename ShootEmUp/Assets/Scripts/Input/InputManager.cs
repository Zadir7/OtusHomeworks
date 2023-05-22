using System;
using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class InputManager : ITickable
    {
        public float HorizontalInput { get; private set; }

        public event Action OnFireInput = () => { };

        void ITickable.Tick()
        {
            CheckHorizontalInput();

            CheckFireInput();
        }

        private void CheckHorizontalInput()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.HorizontalInput = -1;
                return;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.HorizontalInput = 1;
                return;
            }

            this.HorizontalInput = 0;
        }

        private void CheckFireInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireInput.Invoke();
            }
        }
    }
}