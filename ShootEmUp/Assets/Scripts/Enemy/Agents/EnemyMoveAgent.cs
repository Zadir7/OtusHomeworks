using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        [SerializeField] private MoveComponent moveComponent;
        
        public bool HasReachedDestination { get; private set; }
        
        private Vector2 destination;

        private const float DestinationRadius = 0.25f;

        public void SetDestination(Vector2 target)
        {
            this.destination = target;
            this.HasReachedDestination = false;
        }

        private void FixedUpdate()
        {
            if (this.HasReachedDestination)
            {
                return;
            }
            
            MoveToDestination();
        }

        private void MoveToDestination()
        {
            var vector = this.destination - (Vector2)this.transform.position;
            if (vector.magnitude <= DestinationRadius)
            {
                this.HasReachedDestination = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            this.moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}