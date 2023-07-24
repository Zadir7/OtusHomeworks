using Unity.Entities;
using Unity.Transforms;

namespace Mechanics.Attack
{
    public readonly partial struct ShootingAspect : IAspect
    {
        public readonly RefRO<LocalTransform> Transform;
        public readonly RefRO<AttackRange.AttackRange> Range;
        public readonly RefRO<Team.Team> Team;
        public readonly RefRW<Shooter> Shooting;
    }
}