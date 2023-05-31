using System;
using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class CharacterController : IStartable, IDisposable
    {
        private readonly GameManager gameManager;
        private readonly HitPointsComponent hitPointsComponent;

        public CharacterController(GameManager gameManager, CharacterView characterView)
        {
            this.gameManager = gameManager;
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

        private void OnCharacterDeath(GameObject _) => this.gameManager.FinishGame();
    }
}