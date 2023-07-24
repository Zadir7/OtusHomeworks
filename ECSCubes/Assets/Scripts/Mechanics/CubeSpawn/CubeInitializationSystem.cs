using Movement.Speed;
using Movement.TargetPositionMovement;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Mechanics.CubeSpawn
{
    [BurstCompile]
    [UpdateAfter(typeof(CubeSpawnSystem))]
    public partial struct CubeInitializationSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            
            foreach (var freshCube in SystemAPI.Query<FreshSpawnedCube>())
            {
                var entity = freshCube.Entity;
                var initialPosition = freshCube.InitialPosition;
                ecb.RemoveComponent<FreshSpawnedCube>(entity);
                
                var transform = SystemAPI.GetComponentRW<LocalTransform>(entity);
                transform.ValueRW.Position = initialPosition;
                
                var newMovementTarget = new float3(initialPosition.x, 0, -initialPosition.z);
                ecb.AddComponent(entity, new TargetPosition
                {
                    Value = newMovementTarget
                });
                ecb.AddComponent(entity, new Speed
                {
                    Value = 2
                });
            }
            
            ecb.Playback(state.EntityManager);
        }
    }
}