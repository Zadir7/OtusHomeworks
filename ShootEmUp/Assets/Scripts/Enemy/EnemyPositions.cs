using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;

        public Transform GetRandomSpawnPosition()
        {
            return Utilities.Utilities.GetRandomElementInArray(this.spawnPositions);
        }

        public Transform GetRandomAttackPosition()
        {
            return Utilities.Utilities.GetRandomElementInArray(this.attackPositions);
        }
    }
}