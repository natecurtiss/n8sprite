using TMPro;
using UnityEngine;

namespace N8Sprite
{
    [RequireComponent(typeof(TMP_InputField))]
    public sealed class PixelCanvasResizingActions : MonoBehaviour
    {
        [SerializeField]
        private PixelCanvas PixelCanvas;
        
        private TMP_InputField _sizeTextObject;
        private string _currentSizeText;

        private void Awake() => _sizeTextObject = GetComponent<TMP_InputField>();

        private void Start() => _currentSizeText = _sizeTextObject.text;

        public void OnNewSizeInputted(string sizeText)
        {
            if (!int.TryParse(sizeText, out int __size))
            {
                _sizeTextObject.text = _currentSizeText;
                return;
            }
            __size = Mathf.Clamp(__size, CanvasOptions.MINIMUM_SIZE, CanvasOptions.MAXIMUM_SIZE);
            PixelCanvas.ChangeSize(__size);
            _sizeTextObject.text = __size.ToString();
            _currentSizeText = _sizeTextObject.text;
        }
    }
}