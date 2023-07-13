using Unity.Entities;

namespace CubeSpawn
{
    public struct FreshSpawnedCube : IComponentData
    {
        public Entity Entity;
    }
}