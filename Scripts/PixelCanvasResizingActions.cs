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

        public void OnNewSizeInputted(string sizeText)
        {
            if (!int.TryParse(sizeText, out int __size))
            {
                SizeTextObject.text = _currentSizeText;
                return;
            }
            __size = Mathf.Clamp(__size, CanvasOptions.MINIMUM_SIZE, CanvasOptions.MAXIMUM_SIZE);
            PixelCanvas.ChangeSize(__size);
            SizeTextObject.text = __size.ToString();
        }
    }
}