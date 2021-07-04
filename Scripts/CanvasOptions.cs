using UnityEngine;

namespace N8Sprite
{
    public static class CanvasOptions
    {
        /// <summary>
        /// The <see cref="Color"/> that will be painted to the <see cref="PixelCanvas"/> if <see cref="SelectedTool"/> == <see cref="Tool.Brush">Tool.Brush.</see>
        /// </summary>
        public static Color SelectedColor { get; set; } = Color.black;
        /// <summary>
        /// Pixels will be painted if equal to <see cref="Tool.Brush"/>, and will be erased if equal to <see cref="Tool.Eraser">Tool.Eraser.</see>
        /// </summary>
        public static Tool SelectedTool = Tool.Brush;
        public static readonly Vector2Int MaximumSize = new Vector2Int(1024, 1024);
        public static readonly Vector2Int MinimumSize = new Vector2Int(8, 8);
    }
}