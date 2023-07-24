using Unity.Entities;
using Unity.Mathematics;

namespace Movement.TargetPositionMovement
{
    public struct TargetPosition : IComponentData
    {
        public float3 Value;
    }
}