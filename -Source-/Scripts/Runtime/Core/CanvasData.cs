using UnityEngine;

namespace N8Sprite
{
    public static class CanvasData
    {
        /// <summary>
        /// The maximum size of the <see cref="PixelCanvas"/> in pixels.
        /// </summary>
        internal const int MAXIMUM_SIZE = 128;
        /// <summary>
        /// The minimum size of the <see cref="PixelCanvas"/> in pixels.
        /// </summary>
        internal const int MINIMUM_SIZE = 8;
        /// <summary>
        /// The size of the <see cref="PixelCanvas">PixelCanvas.</see>
        /// </summary>
        public static int Size { get; set; } = MINIMUM_SIZE;
        /// <summary>
        /// Pixels will be painted if equal to <see cref="Tool.Brush"/>, and will be erased if equal to
        /// <see cref="Tool.Eraser">Tool.Eraser.</see>
        /// </summary>
        internal static Tool SelectedTool { get; set; } = Tool.Brush;
        /// <summary>
        /// The <see cref="Color"/> that will be painted to the <see cref="PixelCanvas"/>
        /// if <see cref="SelectedTool"/> == <see cref="Tool.Brush">Tool.Brush.</see>
        /// </summary>
        internal static Color SelectedColor { get; set; } = Color.black;
    }
}