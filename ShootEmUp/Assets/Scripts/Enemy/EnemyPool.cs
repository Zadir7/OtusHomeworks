using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Transform worldTransform;
        [SerializeField] private Transform container;
        [SerializeField] private GameObject prefab;
        [SerializeField] private int initialEnemyCount = 7;

        private readonly Queue<GameObject> enemyPool = new();
        private readonly HashSet<GameObject> activeEnemies = new();

        private void Awake()
        {
            for (var i = 0; i < initialEnemyCount; i++)
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
            this.activeEnemies.Add(enemy);

            return enemy;
        }

        public void DespawnEnemy(GameObject enemy)
        {
            if (activeEnemies.Remove(enemy))
            {
                enemy.transform.SetParent(this.container);
                this.enemyPool.Enqueue(enemy);
            }
        }
    }
}