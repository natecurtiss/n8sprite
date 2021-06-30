using N8Sprite.Colors;
using UnityEngine;
using UnityEngine.UI;

namespace N8Sprite.UI
{
    [RequireComponent(typeof(Image))]
    public sealed class ColorImage : MonoBehaviour
    {
        public ColorContainer Color
        {
            set
            {
                _image.color = value.Color;
                _color = value;
            }
        }
        private ColorContainer _color;
        private Image _image;

        private void Awake() => _image = GetComponent<Image>();
    }
}