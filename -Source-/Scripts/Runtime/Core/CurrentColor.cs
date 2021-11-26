using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace N8Sprite
{
    [RequireComponent(typeof(Image))]
    sealed class CurrentColor : MonoBehaviour
    {
        [SerializeField] 
        float _switchColorAnimationDuration = 0.1f;

        Image _image;
        Color _targetColor;

        void Awake()
        {
            _image = GetComponent<Image>();
            _targetColor = CanvasData.SelectedColor;
        }

        void Update()
        {
            if (CanvasData.SelectedColor == Color.clear) return;
            if (CanvasData.SelectedColor != _targetColor)
            {
                _image.DOKill();
                _targetColor = CanvasData.SelectedColor;
                _image.DOColor(_targetColor, _switchColorAnimationDuration);
            }
        }
    }
}