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

        public void SpawnEnemy()
        {
            var enemy = this.enemyPool.SpawnEnemy();
            if (enemy is null) return;
            
            var spawnPosition = this.enemyPositions.GetRandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = this.enemyPositions.GetRandomAttackPosition();
            
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(this.character.gameObject);
            
            EnemySpawned?.Invoke(enemy);
        }

        public void DespawnEnemy(GameObject enemy)
        {
            this.enemyPool.DespawnEnemy(enemy);
        }
    }
}