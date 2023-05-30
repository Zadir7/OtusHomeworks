using System;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class CharacterFireController : IStartable, IDisposable
    {
        private readonly FireInputManager fireInputManager;
        private readonly BulletSpawner bulletSpawner;

        public CharacterFireController(FireInputManager fireInputManager, BulletSpawner bulletSpawner)
        {
            this.fireInputManager = fireInputManager;
            this.bulletSpawner = bulletSpawner;
        }
        
        public void Start()
        {
            this.fireInputManager.OnFireInput += FirePlayerProjectile;
        }

        public void Dispose()
        {
            this.fireInputManager.OnFireInput -= FirePlayerProjectile;
        }

        private void FirePlayerProjectile()
        {
            this.bulletSpawner.SpawnPlayerBullet();
        }
    }
}