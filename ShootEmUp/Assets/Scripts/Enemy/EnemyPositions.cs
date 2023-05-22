using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField]
        private Transform[] spawnPositions;

        [SerializeField]
        private Transform[] attackPositions;

        public Transform RandomSpawnPosition()
        {
            return Utilities.Utilities.GetRandomElementInArray(this.spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return Utilities.Utilities.GetRandomElementInArray(this.attackPositions);
        }
    }
}