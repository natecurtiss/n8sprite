using UnityEngine;

namespace N8Sprite
{
    public sealed class ColorPanel : MonoBehaviour
    {
        [SerializeField]
        private ColorImage ColorImage;

        private Transform _transform;

        private void Awake() => _transform = GetComponent<Transform>();

        private void Start()
        {
            foreach (ColorContainer __color in ColorGenerator.AllColors)
            {
                ColorImage __colorImage = Instantiate(ColorImage, _transform);
                __colorImage.Color = __color;
            }
        }
    }
}