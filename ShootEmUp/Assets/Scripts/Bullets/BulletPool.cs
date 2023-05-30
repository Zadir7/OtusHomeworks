using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletPool : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;
        
        [SerializeField] private Transform container;
        [SerializeField] private Transform worldTransform;

        [SerializeField] private Bullet prefab;

        private readonly Queue<Bullet> bulletPool = new();
        private readonly HashSet<Bullet> activeBullets = new();
        
        public List<Bullet> GetActiveBullets() => activeBullets.ToList();
        
        private void Awake()
        {
            for (var i = 0; i < this.initialCount; i++)
            {
                var bullet = Instantiate(this.prefab, this.container);
                this.bulletPool.Enqueue(bullet);
            }
        }
        
        public Bullet Spawn()
        {
            if (this.bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                bullet = Instantiate(this.prefab, this.worldTransform);
            }

            this.activeBullets.Add(bullet);

            return bullet;
        }

        public void Despawn(Bullet bullet)
        {
            if (this.activeBullets.Remove(bullet))
            {
                bullet.transform.SetParent(this.container);
                this.bulletPool.Enqueue(bullet);
            }
        }
    }
}