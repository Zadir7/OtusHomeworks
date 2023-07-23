using Unity.Entities;
using Unity.Transforms;

namespace Mechanics.Attack
{
    public partial struct ShootingAspect : IAspect
    {
        public RefRO<LocalTransform> Transform;
        public RefRO<AttackRange.AttackRange> Range;
        public RefRO<Team.Team> Team;
        public RefRW<Shooter> Shooting;
    }
}