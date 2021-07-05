using UnityEngine;
using UnityEngine.Serialization;

namespace N8Sprite
{
    public sealed class ColorPanel : MonoBehaviour
    {
        [FormerlySerializedAs("_colorImage")] [FormerlySerializedAs("ColorImage")] [SerializeField]
        private ColorImage _colorImagePrefab;
        
        private Transform _transform;

        private void Awake() => _transform = GetComponent<Transform>();

        private void Start()
        {
            foreach (var color in ColorGenerator.AllColors)
            {
                var colorImage = Instantiate(_colorImagePrefab, _transform);
                colorImage.Color = color;
            }
        }
    }
}