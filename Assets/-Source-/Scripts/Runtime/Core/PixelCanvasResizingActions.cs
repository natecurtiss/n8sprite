using TMPro;
using UnityEngine;

namespace N8Sprite
{
    [RequireComponent(typeof(TMP_InputField))]
    sealed class PixelCanvasResizingActions : MonoBehaviour
    {
        [SerializeField] 
        PixelCanvas _pixelCanvas;

        TMP_InputField _sizeTextObject;
        string _currentSizeText;

        void Awake() => _sizeTextObject = GetComponent<TMP_InputField>();

        void Start() => _currentSizeText = _sizeTextObject.text;

        public void OnNewSizeInputted(string sizeText)
        {
            if (!int.TryParse(sizeText, out var size))
            {
                _sizeTextObject.text = _currentSizeText;
                return;
            }

            size = Mathf.Clamp(size, CanvasData.MINIMUM_SIZE, CanvasData.MAXIMUM_SIZE);
            _pixelCanvas.ChangeSize(size);
            _sizeTextObject.text = size.ToString();
            _currentSizeText = _sizeTextObject.text;
        }
    }
}