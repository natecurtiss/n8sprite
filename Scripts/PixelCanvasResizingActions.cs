using TMPro;
using UnityEngine;

namespace N8Sprite
{
    public sealed class PixelCanvasResizingActions : MonoBehaviour
    {
        [SerializeField]
        private PixelCanvas PixelCanvas;
        
        [SerializeField]
        private TextMeshProUGUI SizeTextObject;
        private string _currentSizeText;

        private void Start() => _currentSizeText = SizeTextObject.text;

        public void OnNewWidthInputted(string widthText)
        {
            if (!int.TryParse(widthText, out int __width))
            {
                SizeTextObject.text = _currentSizeText;
                return;
            }
            __width = Mathf.Clamp(__width, CanvasOptions.MinimumSize.x, CanvasOptions.MaximumSize.x);
            PixelCanvas.ChangeWidth(__width);
            SizeTextObject.text = __width.ToString();
        }
        
        public void OnNewHeightInputted(string heightText)
        {
            if (!int.TryParse(heightText, out int __height))
            {
                SizeTextObject.text = _currentSizeText;
                return;
            }
            __height = Mathf.Clamp(__height, CanvasOptions.MinimumSize.y, CanvasOptions.MaximumSize.y);
            PixelCanvas.ChangeHeight(__height);
            SizeTextObject.text = __height.ToString();
        }
    }
}