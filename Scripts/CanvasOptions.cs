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
        /// <summary>
        /// The maximum size of the <see cref="PixelCanvas"/> in pixels.
        /// </summary>
        public const int MAXIMUM_SIZE = 128;
        /// <summary>
        /// The minimum size of the <see cref="PixelCanvas"/> in pixels.
        /// </summary>
        public const int MINIMUM_SIZE = 8;
    }
}