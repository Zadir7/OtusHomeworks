using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class HorizontalInputManager : ITickable
    {
        public float HorizontalInput { get; private set; }

        void ITickable.Tick()
        {
            CheckHorizontalInput();
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
    }
}