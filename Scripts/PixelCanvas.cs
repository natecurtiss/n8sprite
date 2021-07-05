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
        private RectTransform _parent;
        [SerializeField]
        private float _resizeAnimationTime = 0.1f;
        
        private RawImage _rawImage;
        private RectTransform _rectTransform;
        private Texture2D _texture;
        
        private bool _isMouseOver;

        private Vector2Int CurrentPixelClicked
        {
            get
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, Input.mousePosition, Camera.main, out var localPoint);
                var textureCoordinate = new Vector2Int(Mathf.FloorToInt(localPoint.x + _texture.width / 2f), Mathf.FloorToInt(localPoint.y + _texture.height / 2f));
                return textureCoordinate;
            }
        }

        public void OnPointerEnter(PointerEventData eventData) => _isMouseOver = true;

        public void OnPointerExit(PointerEventData eventData) => _isMouseOver = false;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rawImage = GetComponent<RawImage>();
            _parent.sizeDelta = Vector2.one * CanvasData.MAXIMUM_SIZE;
        }

        private void Start() => CreateTexture(Vector2Int.one * CanvasData.MAXIMUM_SIZE);

        private void Update()
        {
            if (Input.GetMouseButton(0) && _isMouseOver) Paint();
            if (Input.GetKeyDown(KeyCode.Space)) SpriteSaveSystem.Save(_texture); 
        }

        private void CreateTexture(Vector2Int size)
        {
            _texture = new Texture2D(size.x, size.y, TextureFormat.ARGB32, false)
            {
                filterMode = FilterMode.Point, wrapMode = TextureWrapMode.Clamp
            };
            for (var x = 0; x < _texture.width; x++)
                for (var y = 0; y < _texture.height; y++)
                    _texture.SetPixel(x, y, Color.clear);
            _texture.Apply();
            _rawImage.texture = _texture;
        }

        private void Paint()
        {
            var textureCoordinate = CurrentPixelClicked;
            var colorToPaint = CanvasData.SelectedTool == Tool.Brush ? CanvasData.SelectedColor : Color.clear;
            _texture.SetPixel(textureCoordinate.x, textureCoordinate.y, colorToPaint);
            _texture.Apply();
        }

        public void ChangeSize(int size)
        {
            CanvasData.Size = size;
            var localScale = _rectTransform.localScale;
            localScale.x = 1 * (CanvasData.MINIMUM_SIZE / (float) size);
            localScale.y = localScale.x;
            _rectTransform.DOKill();
            _rectTransform.DOScale(localScale, _resizeAnimationTime);
        }
    }
}