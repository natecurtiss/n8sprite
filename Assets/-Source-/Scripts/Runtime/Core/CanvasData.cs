using UnityEngine;

namespace N8Sprite
{
    public static class CanvasData
    {
        internal const int MAXIMUM_SIZE = 128;
        internal const int MINIMUM_SIZE = 8;
        
        public static int Size { get; set; } = MINIMUM_SIZE;
        internal static Tool SelectedTool { get; set; } = Tool.Brush;
        internal static Color SelectedColor { get; set; } = Color.black;
    }
}