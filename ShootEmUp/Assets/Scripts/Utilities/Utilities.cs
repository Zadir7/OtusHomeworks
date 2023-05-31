using UnityEngine;

namespace Utilities
{
    public static class Utilities
    {
        public static T GetRandomElementInArray<T>(this T[] items)
        {
            var index = Random.Range(0, items.Length);
            return items[index];
        }
    }
}