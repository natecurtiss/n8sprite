using TMPro;
using UnityEngine;

namespace N8Sprite
{
    [RequireComponent(typeof(TMP_InputField))]
    internal sealed class PixelCanvasResizingActions : MonoBehaviour
    {
        [SerializeField]
        private PixelCanvas _pixelCanvas;
        
        private TMP_InputField _sizeTextObject;
        private string _currentSizeText;

        private void Awake() => _sizeTextObject = GetComponent<TMP_InputField>();

        private void Start() => _currentSizeText = _sizeTextObject.text;

        public void OnNewSizeInputted(string sizeText)
        {
            if (!int.TryParse(sizeText, out var __size))
            {
                _sizeTextObject.text = _currentSizeText;
                return;
            }

            __size = Mathf.Clamp(__size, CanvasData.MINIMUM_SIZE, CanvasData.MAXIMUM_SIZE);
            _pixelCanvas.ChangeSize(__size);
            _sizeTextObject.text = __size.ToString();
            _currentSizeText = _sizeTextObject.text;
        }
    }
}