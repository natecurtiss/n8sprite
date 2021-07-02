using N8Sprite.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.TerrainAPI;
using UnityEngine.UI;

namespace N8Sprite.UI
{
    [RequireComponent(typeof(RawImage), typeof(RectTransform))]
    public sealed class PixelCanvas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private RawImage _rawImage;
        private RectTransform _rectTransform;
        private Texture2D _texture;

        private bool _isMouseOver;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rawImage = GetComponent<RawImage>();
            EventManager.OnCanvasResolutionChanged.AddListener(CreateTexture);
        }
        
        private void OnDestroy() => EventManager.OnCanvasResolutionChanged.RemoveListener(CreateTexture);

        private void Start() => CreateTexture(new Vector2Int(16, 16));

        private void Update()
        {
            if (Input.GetMouseButton(0) && _isMouseOver) Paint();
        }

        private void CreateTexture(Vector2Int size)
        {
            _texture = new Texture2D(size.x, size.y, TextureFormat.ARGB32, false)
            {
                filterMode = FilterMode.Point,
                wrapMode = TextureWrapMode.Clamp,
            };
            for (int __x = 0; __x < _texture.width; __x++)
                for (int __y = 0; __y < _texture.height; __y++)
                    _texture.SetPixel(__x, __y, Color.clear);
            _texture.Apply();
            _rawImage.texture = _texture;
        }

        private void Paint()
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle
            (
                _rectTransform, 
                Input.mousePosition,
                Camera.main, 
                out Vector2 __localPoint
            );
            Vector2Int __textureCoordinate = new Vector2Int(Mathf.FloorToInt(__localPoint.x + _texture.width / 2f), Mathf.FloorToInt(__localPoint.y + _texture.height / 2f));
            _texture.SetPixel(__textureCoordinate.x, __textureCoordinate.y, ColorImage.SelectedColor);
            _texture.Apply();
        }

        public void OnPointerEnter(PointerEventData eventData) => _isMouseOver = true;

        public void OnPointerExit(PointerEventData eventData) => _isMouseOver = false;
    }
}