using Mechanics.Team;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CubeSpawn
{
    [BurstCompile]
    public partial struct CubeSpawnSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<CubeSpawnProps>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;
            
            var cubeSpawnProps = SystemAPI.GetSingleton<CubeSpawnProps>();
            var prefab = cubeSpawnProps.Prefab;
            var ecb = new EntityCommandBuffer(Allocator.Temp);

            for (int i = 0; i < cubeSpawnProps.Team1Cubes; i++)
            {
                var teamNumber = 1;
                var newCube = ecb.Instantiate(prefab);
                
                ecb.AddComponent(newCube, new Team
                {
                    Number = teamNumber
                });
                ecb.AddComponent(newCube, new FreshSpawnedCube
                {
                    Entity = newCube,
                    InitialPosition = GetCubePosition(i, teamNumber)
                });
            }

            for (int i = 0; i < cubeSpawnProps.Team2Cubes; i++)
            {
                var teamNumber = 2;
                var newCube = ecb.Instantiate(prefab);
                ecb.AddComponent(newCube, new Team
                {
                    Number = teamNumber
                });
                ecb.AddComponent(newCube, new FreshSpawnedCube
                {
                    Entity = newCube,
                    InitialPosition = GetCubePosition(i, teamNumber)
                });
            }
            
            ecb.Playback(state.EntityManager);
        }

        private float3 GetCubePosition(int number, int teamNumber)
        {
            var doubledIndex = number * 2;
            var row = doubledIndex / 100;
            var rowPosition = doubledIndex % 100;
            var isTeam1 = teamNumber == 1;
            var zCoordinateByRow = row * 2;
            if (!isTeam1)
            {
                zCoordinateByRow *= -1;
            }
            return GetCubeStartPosition(isTeam1) + new float3(rowPosition, 0, zCoordinateByRow);
        }

        private float3 GetCubeStartPosition(bool isTeam1)
        {
            var cubeStartingXPosition = -49.0f;
            var cubeStartingZPosition = 15.0f;
            
            return isTeam1 
                ? new float3(cubeStartingXPosition, 0, cubeStartingZPosition) 
                : new float3(cubeStartingXPosition, 0, -cubeStartingZPosition);
        }
    }
}