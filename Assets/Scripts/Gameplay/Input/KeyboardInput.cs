using System;
using Infrastructure.GameEventListeners;
using UnityEngine;
using VContainer.Unity;
using UnityInput = UnityEngine.Input;

namespace Gameplay.Input
{
    public sealed class KeyboardInput : 
        IStartable, 
        IUpdateListener
    {
        public event Action LeftInput = () => { };
        public event Action RightInput = () => { };

        public void Start()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            if (UnityInput.GetKeyDown(KeyCode.LeftArrow))
            {
                LeftInput.Invoke();
                return;
            }

            if (UnityInput.GetKeyDown(KeyCode.RightArrow))
            {
                RightInput.Invoke();
            }
        }
    }
}