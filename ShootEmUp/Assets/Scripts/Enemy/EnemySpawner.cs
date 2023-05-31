using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private CharacterView character;
        [SerializeField] private EnemyPool enemyPool;

        public event Action<GameObject> EnemySpawned;
        
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                
                var enemy = this.SpawnEnemy();
                if (enemy == null) continue;
                
                EnemySpawned?.Invoke(enemy);
            }
        }

        private GameObject SpawnEnemy()
        {
            var enemy = this.enemyPool.SpawnEnemy();
            
            var spawnPosition = this.enemyPositions.GetRandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = this.enemyPositions.GetRandomAttackPosition();
            
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(this.character.gameObject);

            return enemy;
        }

        public void DespawnEnemy(GameObject enemy)
        {
            this.enemyPool.DespawnEnemy(enemy);
        }
    }
}