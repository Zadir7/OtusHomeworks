using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyGenerator : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner;
        
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                
                this.enemySpawner.SpawnEnemy();
            }
        }
    }
}