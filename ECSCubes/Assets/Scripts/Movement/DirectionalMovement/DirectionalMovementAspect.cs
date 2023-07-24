using Movement.DirectionalMovement;
using Unity.Entities;
using Unity.Transforms;

namespace Movement
{
    public readonly partial struct DirectionalMovementAspect : IAspect
    {
        public readonly RefRW<LocalTransform> Transform;
        public readonly RefRO<Speed.Speed> Speed;
        public readonly RefRO<MovementDirection> Direction;
        
        public void Move(float deltaTime)
        {
            Transform.ValueRW.Position += Direction.ValueRO.Value * Speed.ValueRO.Value * deltaTime;
        }
    }
}