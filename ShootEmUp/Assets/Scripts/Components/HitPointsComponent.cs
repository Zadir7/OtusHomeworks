using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> HitPointsEmpty;
        
        [SerializeField] private int hitPoints;
        
        public bool IsNotDead => this.hitPoints > 0;

        public void TakeDamage(int damage)
        {
            this.hitPoints -= damage;
            
            if (this.hitPoints <= 0)
            {
                this.HitPointsEmpty?.Invoke(this.gameObject);
            }
        }
    }
}