using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace N8Sprite
{
    [RequireComponent(typeof(TMP_InputField))]
    public sealed class PixelCanvasResizingActions : MonoBehaviour
    {
        [FormerlySerializedAs("PixelCanvas")] [SerializeField]
        private PixelCanvas _pixelCanvas;
        
        private TMP_InputField _sizeTextObject;
        private string _currentSizeText;

        private void Awake() => _sizeTextObject = GetComponent<TMP_InputField>();

        private void Start() => _currentSizeText = _sizeTextObject.text;

        public void OnNewSizeInputted(string sizeText)
        {
            if (!int.TryParse(sizeText, out var size))
            {
                _sizeTextObject.text = _currentSizeText;
                return;
            }

            size = Mathf.Clamp(size, CanvasOptions.MINIMUM_SIZE, CanvasOptions.MAXIMUM_SIZE);
            _pixelCanvas.ChangeSize(size);
            _sizeTextObject.text = size.ToString();
            _currentSizeText = _sizeTextObject.text;
        }
    }
}