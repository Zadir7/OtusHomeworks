using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = nameof(LevelBackgroundConfig), menuName = "Level/Background Config")]
    public sealed class LevelBackgroundConfig : ScriptableObject
    {
        [SerializeField] public float startPositionY;
        [SerializeField] public float endPositionY;
        [SerializeField] public float speedY;
    }
}