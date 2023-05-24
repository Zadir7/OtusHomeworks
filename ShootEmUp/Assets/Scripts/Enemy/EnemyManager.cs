using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private BulletSystem bulletSystem;
        
        private readonly HashSet<GameObject> activeEnemies = new();

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                
                var enemy = this.enemyPool.SpawnEnemy();
                if (enemy == null) continue;
                
                if (this.activeEnemies.Add(enemy))
                {
                    enemy.GetComponent<HitPointsComponent>().HitPointsEmpty += this.OnDestroyed;
                    enemy.GetComponent<EnemyAttackAgent>().OnFire += this.OnFire;
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HitPointsEmpty -= this.OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= this.OnFire;

                enemyPool.DespawnEnemy(enemy);
            }
        }

        private void OnFire(Vector2 position, Vector2 direction)
        {
            bulletSystem.SpawnEnemyBullet(position, direction);
        }
    }
}