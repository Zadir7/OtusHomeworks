using Unity.Entities;

namespace CubeSpawn
{
    public struct CubeSpawnProps : IComponentData
    {
        public Entity Prefab;
        public int Team1Cubes;
        public int Team2Cubes;
    }
}