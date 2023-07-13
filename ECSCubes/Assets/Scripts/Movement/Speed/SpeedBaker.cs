using Unity.Entities;

namespace Movement.Speed
{
    public class SpeedBaker : Baker<SpeedAuthoring>
    {
        public override void Bake(SpeedAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new SpeedComponent
            {
                Value = authoring.Value
            });
        }
    }
}