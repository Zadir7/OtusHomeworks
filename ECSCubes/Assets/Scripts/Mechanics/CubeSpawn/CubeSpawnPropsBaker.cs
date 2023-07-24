using Unity.Entities;

namespace Mechanics.CubeSpawn
{
    public class CubeSpawnPropsBaker : Baker<CubeSpawnPropsAuthoring>
    {
        public override void Bake(CubeSpawnPropsAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new CubeSpawnProps
            {
                Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                Team1Cubes = authoring.Team1Cubes,
                Team2Cubes = authoring.Team2Cubes
            });
        }
    }
}