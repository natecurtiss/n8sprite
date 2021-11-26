using UnityEngine;

namespace N8Sprite
{
    sealed class ColorPanel : MonoBehaviour
    {
        [SerializeField] 
        ColorImage _colorImagePrefab;

        Transform _transform;

        void Awake() => _transform = GetComponent<Transform>();

        void Start()
        {
            foreach (var color in ColorGenerator.AllColors)
            {
                var colorImage = Instantiate(_colorImagePrefab, _transform);
                colorImage.Color = color;
            }
        }
    }
}