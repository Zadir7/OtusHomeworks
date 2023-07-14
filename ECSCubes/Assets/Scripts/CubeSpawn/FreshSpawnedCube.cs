using Unity.Entities;
using Unity.Mathematics;

namespace CubeSpawn
{
    public struct FreshSpawnedCube : IComponentData
    {
        public Entity Entity;
        public float3 InitialPosition;
    }
}