using Movement.TargetPosition;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CubeSpawn
{
    [BurstCompile]
    public partial struct CubeInitializationSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var freshCube in SystemAPI.Query<FreshSpawnedCube>())
            {
                var entity = freshCube.Entity;
                ecb.RemoveComponent<FreshSpawnedCube>(entity);
                var transform = SystemAPI.GetComponentRW<LocalTransform>(entity);
                
                var newMovementTarget = new float3(-transform.ValueRW.Position.x, 0, transform.ValueRW.Position.z);
                ecb.AddComponent(entity, new TargetPosition
                {
                    Value = newMovementTarget
                });
            }
        }
    }
}