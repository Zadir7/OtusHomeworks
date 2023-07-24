using Unity.Entities;

namespace Mechanics.CubeSpawn
{
    public struct CubeSpawnProps : IComponentData
    {
        public Entity Prefab;
        public int Team1Cubes;
        public int Team2Cubes;
    }
}