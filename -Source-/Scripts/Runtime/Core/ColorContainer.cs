using System;
using UnityEngine;

namespace N8Sprite
{
    public readonly struct ColorContainer
    {
        public readonly Color32 Color;
        public readonly ConsoleColor ForegroundColor;
        public readonly ConsoleColor BackgroundColor;
        
        public int Hue
        {
            get
            {
                UnityEngine.Color.RGBToHSV(Color, out var hue, out var saturation, out var value);
                return Mathf.RoundToInt(hue * 10f);
            }
        }
        
        public ColorContainer(Color32 color, ConsoleColor consoleColor)
        {
            Color = color;
            ForegroundColor = consoleColor;
            BackgroundColor = consoleColor;
        }
        
        public ColorContainer(Color32 color, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Color = color;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }
    }
}