using UnityEngine;
using UnityEngine.UI;

namespace N8Sprite
{
    [RequireComponent(typeof(Image))]
    public sealed class ToggleableImage : MonoBehaviour
    {
        [SerializeField] 
        Sprite _otherSprite;

        Sprite _firstSprite;
        Image _image;

        void Awake()
        {
            _image = GetComponent<Image>();
            _firstSprite = _image.sprite;
        }

        public void Toggle() => _image.sprite = _image.sprite == _firstSprite ? _otherSprite : _firstSprite;
    }
}