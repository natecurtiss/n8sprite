using N8Sprite.Colors;
using UnityEngine;

namespace N8Sprite.UI
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            foreach (ColorContainer __color in ColorGenerator.AllColors) 
                Debug.Log($"{__color.Color} {__color.BackgroundColor} {__color.ForegroundColor}");
        }
    }
}