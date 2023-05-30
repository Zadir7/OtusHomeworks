using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;
        
        [SerializeField] private Transform container;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private LevelBounds levelBounds;
        
        [SerializeField] private Bullet prefab;

        private readonly Queue<Bullet> bulletPool = new();
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> bulletCache = new();

        private void Awake()
        {
            for (var i = 0; i < this.initialCount; i++)
            {
                var bullet = Instantiate(this.prefab, this.container);
                this.bulletPool.Enqueue(bullet);
            }
        }
        
        private void FixedUpdate()
        {
            this.bulletCache.Clear();
            this.bulletCache.AddRange(activeBullets);

            for (int i = 0, count = this.bulletCache.Count; i < count; i++)
            {
                var bullet = this.bulletCache[i];
                if (!this.levelBounds.InBounds(bullet.transform.position))
                {
                    this.RemoveBullet(bullet);
                }
            }
        }

        public void SpawnEnemyBullet(Vector2 position, Vector2 direction)
        {
            this.SpawnBullet(new BulletSpawnArgs
            {
                IsPlayer = false,
                PhysicsLayer = (int)PhysicsLayer.ENEMY_BULLET,
                Color = Color.red,
                Damage = 1,
                Position = position,
                Velocity = direction * 2.0f
            });
        }

        public void SpawnPlayerBullet(BulletConfig bulletConfig, WeaponComponent weapon)
        {
            this.SpawnBullet(new BulletSpawnArgs
            {
                IsPlayer = true,
                PhysicsLayer = (int)bulletConfig.physicsLayer,
                Color = bulletConfig.color,
                Damage = bulletConfig.damage,
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * bulletConfig.speed
            });
        }

        private void SpawnBullet(BulletSpawnArgs bulletSpawnArgs)
        {
            if (this.bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                bullet = Instantiate(this.prefab, this.worldTransform);
            }

            bullet.SetPosition(bulletSpawnArgs.Position);
            bullet.SetColor(bulletSpawnArgs.Color);
            bullet.SetPhysicsLayer(bulletSpawnArgs.PhysicsLayer);
            bullet.Damage = bulletSpawnArgs.Damage;
            bullet.IsPlayer = bulletSpawnArgs.IsPlayer;
            bullet.SetVelocity(bulletSpawnArgs.Velocity);
            
            if (this.activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += this.OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            this.RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (this.activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= this.OnBulletCollision;
                bullet.transform.SetParent(this.container);
                this.bulletPool.Enqueue(bullet);
            }
        }
    }
}