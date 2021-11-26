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
        RectTransform _parent;
        [SerializeField] 
        float _resizeAnimationTime = 0.1f;

        RawImage _rawImage;
        RectTransform _rectTransform;
        bool _isMouseOver;
        
        public Texture2D Texture { get; private set; }

        Vector2Int CurrentPixelClicked
        {
            get
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle
                    (_rectTransform, Input.mousePosition, Camera.main, out var localPoint);
                var textureCoordinate = new Vector2Int
                (
                    Mathf.FloorToInt(localPoint.x + Texture.width / 2f), 
                    Mathf.FloorToInt(localPoint.y + Texture.height / 2f)
                );
                return textureCoordinate;
            }
        }

        public void OnPointerEnter(PointerEventData eventData) => _isMouseOver = true;

        public void OnPointerExit(PointerEventData eventData) => _isMouseOver = false;

        void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rawImage = GetComponent<RawImage>();
            _parent.sizeDelta = Vector2.one * CanvasData.MAXIMUM_SIZE;
        }

        void Start() => CreateTexture(Vector2Int.one * CanvasData.MAXIMUM_SIZE);

        void Update()
        {
            if (Input.GetMouseButton(0) && _isMouseOver) Paint();
        }

        void CreateTexture(Vector2Int size)
        {
            Texture = new Texture2D(size.x, size.y, TextureFormat.ARGB32, false)
            {
                filterMode = FilterMode.Point, wrapMode = TextureWrapMode.Clamp
            };
            for (var x = 0; x < Texture.width; x++)
                for (var y = 0; y < Texture.height; y++)
                    Texture.SetPixel(x, y, Color.clear);
            Texture.Apply();
            _rawImage.texture = Texture;
        }

        void Paint()
        {
            var textureCoordinate = CurrentPixelClicked;
            var colorToPaint = CanvasData.SelectedTool == Tool.Brush ? CanvasData.SelectedColor : Color.clear;
            Texture.SetPixel(textureCoordinate.x, textureCoordinate.y, colorToPaint);
            Texture.Apply();
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