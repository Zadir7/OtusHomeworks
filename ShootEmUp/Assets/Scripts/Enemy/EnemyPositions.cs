using UnityEngine;
using Utilities;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;

        public Transform GetRandomSpawnPosition()
        {
            return this.spawnPositions.GetRandomElementInArray();
        }

        public Transform GetRandomAttackPosition()
        {
            return this.attackPositions.GetRandomElementInArray();
        }
    }
}