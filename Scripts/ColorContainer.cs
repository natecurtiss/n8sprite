using System;
using UnityEngine;

namespace N8Sprite
{
    /// <summary>
    /// A struct that contains a foreground <see cref="ConsoleColor"/>, a background <see cref="ConsoleColor" />, and the
    /// result of mixing the two.
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
                Color.RGBToHSV(Color, out var hue, out var saturation, out var value);
                return Mathf.RoundToInt(hue * 10f);
            }
        }

        /// <summary>
        /// A constructor to create one of the base <see cref="ConsoleColor">ConsoleColors.</see>
        /// </summary>
        /// <param name="color"> The RGBA of the base color. </param>
        /// <param name="consoleColor"> The <see cref="ConsoleColor"/> enum value of the base color. </param>
        public ColorContainer(Color color, ConsoleColor consoleColor)
        {
            Color = color;
            ForegroundColor = consoleColor;
            BackgroundColor = consoleColor;
        }

        /// <summary>
        /// A constructor to create a <see cref="ColorContainer"/> that is the result of mixing two <see cref="ConsoleColor">ConsoleColors.</see>
        /// </summary>
        /// <param name="color"> The RGBA of the mixed color. </param>
        /// <param name="foregroundColor"> The first <see cref="ConsoleColor"/> enum value. </param>
        /// <param name="backgroundColor"> The second <see cref="ConsoleColor"/> enum value. </param>
        public ColorContainer(Color color, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Color = color;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }
    }
}