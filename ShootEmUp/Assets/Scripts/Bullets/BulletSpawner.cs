using System;
using UnityEngine;
using VContainer;

namespace ShootEmUp
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private BulletConfig playerBulletConfig;
        
        private WeaponComponent characterWeapon;
        private BulletPool bulletPool;

        public event Action<Bullet> BulletSpawned; 

        [Inject]
        public void Construct(BulletPool pool, CharacterView characterView)
        {
            this.bulletPool = pool;
            this.characterWeapon = characterView.GetComponent<WeaponComponent>();
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

        public void SpawnPlayerBullet()
        {
            this.SpawnBullet(new BulletSpawnArgs
            {
                IsPlayer = true,
                PhysicsLayer = (int)this.playerBulletConfig.physicsLayer,
                Color = this.playerBulletConfig.color,
                Damage = this.playerBulletConfig.damage,
                Position = characterWeapon.Position,
                Velocity = characterWeapon.Rotation * Vector3.up * playerBulletConfig.speed
            });
        }

        private void SpawnBullet(BulletSpawnArgs bulletSpawnArgs)
        {
            var bullet = bulletPool.Spawn();
            
            bullet.SetPosition(bulletSpawnArgs.Position);
            bullet.SetColor(bulletSpawnArgs.Color);
            bullet.SetPhysicsLayer(bulletSpawnArgs.PhysicsLayer);
            bullet.Damage = bulletSpawnArgs.Damage;
            bullet.IsPlayer = bulletSpawnArgs.IsPlayer;
            bullet.SetVelocity(bulletSpawnArgs.Velocity);
            
            BulletSpawned?.Invoke(bullet);
        }
    }
}