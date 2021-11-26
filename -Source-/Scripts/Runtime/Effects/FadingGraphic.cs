using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace N8Sprite
{
    [RequireComponent(typeof(Graphic))]
    public sealed class FadingGraphic : MonoBehaviour
    {
        [SerializeField] 
        float _animationDuration = 0.5f;
        [SerializeField] 
        bool _isVisible = true;

        Graphic _graphic;

        void Awake() => _graphic = GetComponent<Graphic>();

        public void Toggle()
        {
            _graphic.DOFade(!_isVisible ? 1f : 0f, _animationDuration);
            _isVisible = !_isVisible;
        }
    }
}