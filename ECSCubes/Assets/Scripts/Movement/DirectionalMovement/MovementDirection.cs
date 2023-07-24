using Unity.Entities;
using Unity.Mathematics;

namespace Movement.DirectionalMovement
{
    public struct MovementDirection : IComponentData
    {
        public float3 Value;
    }
}