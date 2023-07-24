using Unity.Entities;

namespace Mechanics.Attack
{
    public struct CurrentTarget : IComponentData
    {
        public Entity Value;
    }
}