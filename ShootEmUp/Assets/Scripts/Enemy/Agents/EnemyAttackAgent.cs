using System;
using UnityEngine;
using Utilities;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public event Action<Vector2, Vector2> OnFire;

        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown;

        private GameObject firingTarget;
        private Timer firingTimer;

        private void OnEnable()
        {
            firingTimer.OnExpire += Fire;
        }

        private void OnDisable()
        {
            firingTimer.OnExpire -= Fire;
        }

        public void SetTarget(GameObject target)
        {
            this.firingTarget = target;
        }

        public void Reset()
        {
            this.firingTimer.Reset();
        }

        private void FixedUpdate()
        {
            if (!this.moveAgent.HasReachedDestination)
            {
                return;
            }

            if (!this.firingTarget.GetComponent<HitPointsComponent>().IsNotDead())
            {
                return;
            }
            
            this.firingTimer.Update(Time.fixedDeltaTime);
        }

        private void Fire()
        {
            var weaponPosition = this.weaponComponent.Position;
            var vector = (Vector2)this.firingTarget.transform.position - weaponPosition;
            var direction = vector.normalized;
            this.OnFire?.Invoke(weaponPosition, direction);
        }
    }
}