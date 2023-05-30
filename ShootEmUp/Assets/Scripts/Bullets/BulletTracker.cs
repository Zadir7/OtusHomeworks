using System;
using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public class BulletTracker : IStartable, IFixedTickable, IDisposable
    {
        private readonly BulletSpawner bulletSpawner;
        private readonly BulletPool bulletPool;
        private readonly LevelBounds levelBounds;

        public BulletTracker(BulletSpawner bulletSpawner, BulletPool bulletPool, LevelBounds levelBounds)
        {
            this.bulletSpawner = bulletSpawner;
            this.bulletPool = bulletPool;
            this.levelBounds = levelBounds;
        }
        
        void IStartable.Start()
        {
            bulletSpawner.BulletSpawned += OnBulletSpawn;
        }

        void IDisposable.Dispose()
        {
            bulletSpawner.BulletSpawned -= OnBulletSpawn;
        }

        void IFixedTickable.FixedTick()
        {
            var activeBullets = this.bulletPool.GetActiveBullets();

            for (int i = 0, count = activeBullets.Count; i < count; i++)
            {
                var bullet = activeBullets[i];
                if (!this.levelBounds.InBounds(bullet.transform.position))
                {
                    bulletPool.Despawn(bullet);
                }
            }
        }

        private void OnBulletSpawn(Bullet bullet)
        {
            bullet.OnCollisionEntered += OnBulletCollision;
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            DealDamage(bullet, collision.gameObject);
            bullet.OnCollisionEntered -= OnBulletCollision;
            this.bulletPool.Despawn(bullet);
        }
        
        private static void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (bullet.IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.Damage);
            }
        }
    }
}