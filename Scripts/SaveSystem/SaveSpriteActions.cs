using UnityEngine;

namespace N8Sprite.SaveSystem
{
    public sealed class SaveSpriteActions : MonoBehaviour
    {
        [SerializeField]
        private PixelCanvas _pixelCanvas;
        
        public void SaveSprite() => SpriteSaveSystem.Save(_pixelCanvas.Texture);
    }
}