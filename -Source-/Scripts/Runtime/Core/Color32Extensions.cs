using UnityEngine;

namespace N8Sprite
{
    static class Color32Extensions
    {
        public static bool IsEqualTo(this Color32 first, Color32 second) =>
            first.r == second.r && first.g == second.g && first.b == second.b && first.a == second.a;
    }
}