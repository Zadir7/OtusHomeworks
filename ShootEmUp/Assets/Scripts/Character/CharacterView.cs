using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(HitPointsComponent))]
    [RequireComponent(typeof(MoveComponent))]
    [RequireComponent(typeof(WeaponComponent))]
    [RequireComponent(typeof(TeamComponent))]
    public sealed class CharacterView : MonoBehaviour
    {
    }
}