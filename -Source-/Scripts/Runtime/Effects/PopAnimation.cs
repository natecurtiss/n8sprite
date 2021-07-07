using DG.Tweening;
using UnityEngine;

namespace N8Sprite
{
    public sealed class PopAnimation : MonoBehaviour
    {
        [SerializeField]
        private float _popAnimationDuration = 0.3f;
        [SerializeField]
        private float _popAnimationPower = 0.2f;
        
        private Transform _transform;

        private void Awake() => _transform = GetComponent<Transform>();

        public void Play()
        {
            _transform.DOKill(true);
            _transform.DOPunchScale(Vector3.one * _popAnimationPower, _popAnimationDuration);
        }
    }
}