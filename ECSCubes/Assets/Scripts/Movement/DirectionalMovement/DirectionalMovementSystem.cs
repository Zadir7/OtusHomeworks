using Unity.Burst;
using Unity.Entities;

namespace Movement.DirectionalMovement
{
    [BurstCompile]
    public partial struct DirectionalMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            foreach (var movementAspect in SystemAPI.Query<DirectionalMovementAspect>())
            {
                movementAspect.Move(deltaTime);
            }
        }
    }
}