using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace N8Sprite
{
    [RequireComponent(typeof(RawImage), typeof(RectTransform))]
    public sealed class PixelCanvas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private RectTransform Parent;
        private RectTransform _rectTransform;
        private RawImage _rawImage;
        private Texture2D _texture;

        [SerializeField, Range(0.1f, 1f)]
        private float ResizeAnimationTime = 0.1f;

        private bool _isMouseOver;

        private Vector2Int CurrentPixelClicked
        {
            get
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle
                (
                    _rectTransform, 
                    Input.mousePosition,
                    Camera.main, 
                    out Vector2 __localPoint
                );
                Vector2Int __textureCoordinate = new Vector2Int(Mathf.FloorToInt(__localPoint.x + _texture.width / 2f), Mathf.FloorToInt(__localPoint.y + _texture.height / 2f));
                return __textureCoordinate;
            }
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rawImage = GetComponent<RawImage>();
            Parent.sizeDelta = Vector2.one * CanvasOptions.MAXIMUM_SIZE;
        }

        private void Start() => CreateTexture(Vector2Int.one * CanvasOptions.MAXIMUM_SIZE);

        private void Update()
        {
            if (Input.GetMouseButton(0) && _isMouseOver) Paint();
        }
        
        public void OnPointerEnter(PointerEventData eventData) => _isMouseOver = true;

        public void OnPointerExit(PointerEventData eventData) => _isMouseOver = false;
        
        private void CreateTexture(in Vector2Int size)
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
            Vector2Int __textureCoordinate = CurrentPixelClicked;
            Color __colorToPaint = CanvasOptions.SelectedTool == Tool.Brush ? CanvasOptions.SelectedColor : Color.clear;
            _texture.SetPixel(__textureCoordinate.x, __textureCoordinate.y, __colorToPaint);
            _texture.Apply();
        }

        public void ChangeSize(in int size)
        {
            Vector3 __localScale = _rectTransform.localScale;
            __localScale.x = 1 * (CanvasOptions.MINIMUM_SIZE / (float) size);
            __localScale.y = __localScale.x;
            _rectTransform.DOKill();
            _rectTransform.DOScale(__localScale, ResizeAnimationTime);
        }
    }
}