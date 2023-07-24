using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Movement.TargetPositionMovement
{
    public readonly partial struct TargetPositionMovementAspect : IAspect
    {
        public readonly RefRW<LocalTransform> Transform;
        public readonly RefRO<Speed.Speed> Speed;
        public readonly RefRW<TargetPosition> TargetPosition;

        public void Move(float deltaTime)
        {
            var target = TargetPosition.ValueRW.Value;
            var direction = target - Transform.ValueRW.Position;

            var normalizedDirection = math.normalize(direction);
            Transform.ValueRW.Position += normalizedDirection * Speed.ValueRO.Value * deltaTime;
        }

        public bool HasReachedTargetPosition()
        {
            return math.distancesq(TargetPosition.ValueRW.Value, Transform.ValueRW.Position) < 1;
        }
    }
}