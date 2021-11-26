using UnityEngine;
using UnityEngine.UI;

namespace N8Sprite
{
    [RequireComponent(typeof(Image))]
    sealed class ColorImage : MonoBehaviour
    {
        ColorContainer _color;
        Image _image;

        public ColorContainer Color
        {
            set
            {
                _image.color = value.Color;
                _color = value;
            }
        }

        void Awake() => _image = GetComponent<Image>();

        public void ChangeSelectedColor() => CanvasData.SelectedColor = _color.Color;
    }
}