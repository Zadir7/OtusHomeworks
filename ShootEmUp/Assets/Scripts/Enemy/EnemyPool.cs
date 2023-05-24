using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private CharacterView character;

        [Header("Pool")]
        
        [SerializeField] private Transform worldTransform;
        [SerializeField] private Transform container;
        [SerializeField] private GameObject prefab;

        private readonly Queue<GameObject> enemyPool = new();

        private const int InitialEnemyCount = 7;
        
        private void Awake()
        {
            for (var i = 0; i < InitialEnemyCount; i++)
            {
                var enemy = Instantiate(this.prefab, this.container);
                this.enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!this.enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

            enemy.transform.SetParent(this.worldTransform);

            var spawnPosition = this.enemyPositions.GetRandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            var attackPosition = this.enemyPositions.GetRandomAttackPosition();
            
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(this.character.gameObject);
            
            return enemy;
        }

        public void DespawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(this.container);
            this.enemyPool.Enqueue(enemy);
        }
    }
}