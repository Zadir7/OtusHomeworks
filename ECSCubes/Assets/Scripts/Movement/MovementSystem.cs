using Unity.Burst;
using Unity.Entities;

namespace Movement
{
    [BurstCompile]
    public partial struct MovementSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            foreach (var movementAspect in SystemAPI.Query<MovementAspect>())
            {
                movementAspect.Move(deltaTime);
            }
        }
    }
}