using Unity.Burst;
using Unity.Entities;

namespace Movement.TargetPositionMovement
{
    [BurstCompile]
    public partial struct TargetPositionMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            foreach (var movementAspect in SystemAPI.Query<TargetPositionMovementAspect>())
            {
                movementAspect.Move(deltaTime);
            }
        }
    }
}