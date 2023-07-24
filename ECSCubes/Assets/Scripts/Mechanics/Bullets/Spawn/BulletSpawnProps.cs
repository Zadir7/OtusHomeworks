using Unity.Entities;

namespace Mechanics.Bullets.Spawn
{
    public partial struct BulletSpawnProps : IComponentData
    {
        public Entity Prefab;
        public float Lifetime;
        public float CollisionDamage;
    }
}