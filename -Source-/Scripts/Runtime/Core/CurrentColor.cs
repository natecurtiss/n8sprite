using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace N8Sprite
{
    [RequireComponent(typeof(Image))]
    internal sealed class CurrentColor : MonoBehaviour
    {
        [SerializeField]
        private float _switchColorAnimationDuration = 0.1f;
        
        private Image _image;
        private Color _targetColor;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _targetColor = CanvasData.SelectedColor;
        }

        private void Update()
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