using UnityEngine;
using UnityEngine.UI;

namespace N8Sprite
{
    [RequireComponent(typeof(Image))]
    public sealed class ToggleableImage : MonoBehaviour
    {
        [SerializeField]
        private Sprite _otherSprite;
        
        private Sprite _firstSprite;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _firstSprite = _image.sprite;
        }

        public void Toggle() => _image.sprite = _image.sprite == _firstSprite ? _otherSprite : _firstSprite;
    }
}