using System;
using UnityEngine;

namespace N8Sprite
{
    /// <summary>
    /// A struct that contains a foreground <see cref="ConsoleColor"/>, a background <see cref="ConsoleColor"/>, and the result of mixing the two.
    /// </summary>
    public readonly struct ColorContainer
    {
        /// <summary>
        /// The result of mixing the <see cref="ForegroundColor"/> and the <see cref="BackgroundColor">BackgroundColor.</see>
        /// </summary>
        public readonly Color Color;
        /// <summary>
        /// The foreground <see cref="ConsoleColor"/> to set the <see cref="Console">Console.</see>
        /// </summary>
        public readonly ConsoleColor ForegroundColor;
        /// <summary>
        /// The background <see cref="ConsoleColor"/> to set the <see cref="Console">Console.</see>
        /// </summary>
        public readonly ConsoleColor BackgroundColor;

        /// <summary>
        /// The hue of the <see cref="Color">Color.</see>
        /// </summary>
        public int Hue
        {
            get
            {
                Color.RGBToHSV(Color, out float __hue, out float __saturation, out float __value);
                return Mathf.RoundToInt(__hue * 10f);
            }
        }

        /// <summary>
        /// A constructor to create one of the base <see cref="ConsoleColor">ConsoleColors.</see>
        /// </summary>
        /// <param name="color"></param>
        /// <param name="consoleColor"></param>
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