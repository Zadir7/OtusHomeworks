using System;
using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class EnemyObserver : IStartable, IDisposable
    {
        private readonly BulletSpawner bulletSpawner; 
        private readonly EnemySpawner enemySpawner;

        public EnemyObserver(BulletSpawner bulletSpawner, EnemySpawner enemySpawner)
        {
            this.bulletSpawner = bulletSpawner;
            this.enemySpawner = enemySpawner;
        }

        public void Start()
        {
            enemySpawner.EnemySpawned += OnEnemySpawned;
        }

        public void Dispose()
        {
            enemySpawner.EnemySpawned -= OnEnemySpawned;
        }

        private void OnEnemySpawned(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().HitPointsEmpty += this.OnEnemyDestroyed;
            enemy.GetComponent<EnemyAttackAgent>().OnFire += this.OnFire;
        }

        private void OnEnemyDestroyed(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().HitPointsEmpty -= this.OnEnemyDestroyed;
            enemy.GetComponent<EnemyAttackAgent>().OnFire -= this.OnFire;
            
            this.enemySpawner.DespawnEnemy(enemy);
        }
        
        private void OnFire(Vector2 position, Vector2 direction)
        {
            bulletSpawner.SpawnEnemyBullet(position, direction);
        }
    }
}