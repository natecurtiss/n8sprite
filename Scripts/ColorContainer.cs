using System;
using UnityEngine;

namespace N8Sprite
{
    public readonly struct ColorContainer
    {
        public readonly Color Color;
        public readonly ConsoleColor ForegroundColor;
        public readonly ConsoleColor BackgroundColor;

        public int Hue
        {
            get
            {
                Color.RGBToHSV(Color, out float __hue, out float __saturation, out float __value);
                return Mathf.RoundToInt(__hue * 10f);
            }
        }

        public ColorContainer(in Color color, in ConsoleColor consoleColor)
        {
            Color = color;
            ForegroundColor = consoleColor;
            BackgroundColor = consoleColor;
        }
        
        public ColorContainer(in Color color, in ConsoleColor foregroundColor, in ConsoleColor backgroundColor)
        {
            Color = color;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }
    }
}