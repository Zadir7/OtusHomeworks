using Unity.Entities;

namespace Mechanics.Bullets.Spawn
{
    public class BulletSpawnPropsBaker : Baker<BulletSpawnPropsAuthoring>
    {
        public override void Bake(BulletSpawnPropsAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new BulletSpawnProps
            {
                Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                CollisionDamage = authoring.CollisionDamage,
                Lifetime = authoring.Lifetime
            });
        }
    }
}