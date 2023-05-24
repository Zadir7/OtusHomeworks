using System;
using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class CharacterController : IStartable, IDisposable
    {
        private readonly HitPointsComponent hitPointsComponent;

        public event Action OnPlayerDeath = () => { };

        public CharacterController(CharacterView characterView)
        {
            this.hitPointsComponent = characterView.GetComponent<HitPointsComponent>();
        }
        
        void IStartable.Start()
        {
            hitPointsComponent.HitPointsEmpty += this.OnCharacterDeath;
        }

        void IDisposable.Dispose()
        {
            hitPointsComponent.HitPointsEmpty -= this.OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => this.OnPlayerDeath.Invoke();
    }
}