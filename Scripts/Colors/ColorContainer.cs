using System;
using UnityEngine;

namespace N8Sprite.Colors
{
    public readonly struct ColorContainer
    {
        public readonly Color Color;
        public readonly ConsoleColor ForegroundColor;
        public readonly ConsoleColor BackgroundColor;

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