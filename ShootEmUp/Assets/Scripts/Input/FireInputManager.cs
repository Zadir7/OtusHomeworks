using System;
using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public class FireInputManager : ITickable
    {
        public event Action OnFireInput;
        
        void ITickable.Tick()
        {
            CheckFireInput();
        }
        
        private void CheckFireInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireInput?.Invoke();
            }
        }
    }
}