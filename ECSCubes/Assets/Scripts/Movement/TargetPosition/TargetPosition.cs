using Unity.Entities;
using Unity.Mathematics;

namespace Movement.TargetPosition
{
    public struct TargetPosition : IComponentData
    {
        public float3 Value;
    }
}