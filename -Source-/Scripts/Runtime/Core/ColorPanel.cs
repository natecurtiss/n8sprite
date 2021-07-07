using UnityEngine;

namespace N8Sprite
{
    internal sealed class ColorPanel : MonoBehaviour
    {
        [SerializeField]
        private ColorImage _colorImagePrefab;
        
        private Transform _transform;

        private void Awake() => _transform = GetComponent<Transform>();

        private void Start()
        {
            foreach (ColorContainer __color in ColorGenerator.AllColors)
            {
                ColorImage __colorImage = Instantiate(_colorImagePrefab, _transform);
                __colorImage.Color = __color;
            }
        }
    }
}