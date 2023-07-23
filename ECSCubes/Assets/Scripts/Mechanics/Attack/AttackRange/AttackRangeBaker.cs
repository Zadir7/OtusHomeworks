using Unity.Entities;

namespace Mechanics.Attack.AttackRange
{
    public class AttackRangeBaker : Baker<AttackRangeAuthoring>
    {
        public override void Bake(AttackRangeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new AttackRange
            {
                Value = authoring.Value
            });
        }
    }
}