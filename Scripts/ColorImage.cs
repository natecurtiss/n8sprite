using UnityEngine;
using UnityEngine.UI;

namespace N8Sprite
{
    [RequireComponent(typeof(Image))]
    public sealed class ColorImage : MonoBehaviour
    {
        private ColorContainer _color;
        private Image _image;
        
        public ColorContainer Color
        {
            set
            {
                _image.color = value.Color;
                _color = value;
            }
        }

        private void Awake() => _image = GetComponent<Image>();
        
        public void ChangeSelectedColor() => CanvasOptions.SelectedColor = _color.Color;
    }
}