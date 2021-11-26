using DG.Tweening;
using UnityEngine;

namespace N8Sprite
{
    public sealed class PopAnimation : MonoBehaviour
    {
        [SerializeField] 
        float _popAnimationDuration = 0.3f;
        [SerializeField] 
        float _popAnimationPower = 0.2f;

        Transform _transform;

        void Awake() => _transform = GetComponent<Transform>();

        public void Play()
        {
            _transform.DOKill(true);
            _transform.DOPunchScale(Vector3.one * _popAnimationPower, _popAnimationDuration);
        }
    }
}