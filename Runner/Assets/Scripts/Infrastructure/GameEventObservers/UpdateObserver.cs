using System.Collections.Generic;
using Infrastructure.GameEventListeners;
using UnityEngine;
using VContainer;

namespace Infrastructure.GameEventObservers
{
    public sealed class UpdateObserver : MonoBehaviour
    {
        [Inject]
        private IEnumerable<IUpdateListener> _updateListeners;
        
        [Inject]
        private IEnumerable<IFixedUpdateListener> _fixedUpdateListeners;
        
        [Inject]
        private IEnumerable<ILateUpdateListener> _lateUpdateListeners;
        
        private void Update()
        {
            if (_updateListeners is null) return;
            
            float deltaTime = Time.deltaTime;
            foreach (var listener in _updateListeners)
            {
                listener.OnUpdate(deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (_fixedUpdateListeners is null) return;
            
            float deltaTime = Time.fixedDeltaTime;
            foreach (var listener in _fixedUpdateListeners)
            {
                listener.OnFixedUpdate(deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (_lateUpdateListeners is null) return;
            
            float deltaTime = Time.deltaTime;
            foreach (var listener in _lateUpdateListeners)
            {
                listener.OnLateUpdate(deltaTime);
            }
        }
    }
}