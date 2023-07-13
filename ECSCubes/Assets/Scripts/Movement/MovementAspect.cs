using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Movement
{
    public readonly partial struct MovementAspect : IAspect
    {
        public readonly RefRW<LocalTransform> Transform;
        public readonly RefRO<Speed.Speed> Speed;
        public readonly RefRW<TargetPosition.TargetPosition> TargetPosition;

        public void Move(float deltaTime)
        {
            var target = TargetPosition.ValueRW.Value;
            var currentPosition = Transform.ValueRW.Position;
            var direction = target - currentPosition;

            var normalizedDirection = math.normalize(direction);
            currentPosition += normalizedDirection * Speed.ValueRO.Value * deltaTime;
        }

        public bool HasReachedTargetPosition()
        {
            return math.distancesq(TargetPosition.ValueRW.Value, Transform.ValueRW.Position) < 1;
        }
    }
}