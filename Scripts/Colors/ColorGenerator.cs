using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace N8Sprite.Colors
{
    public static class ColorGenerator
    {
        public static IEnumerable<ColorContainer> AllColors => _baseColors.Concat(MixedColors).ToArray().SortColorsByHue();
        
        private static readonly ColorContainer[] _baseColors = 
        {
            new ColorContainer(new Color32(0, 0, 0, 255), ConsoleColor.Black),
            new ColorContainer(new Color32(0, 0, 139, 255), ConsoleColor.DarkBlue),
            new ColorContainer(new Color32(0, 100, 0, 255), ConsoleColor.DarkGreen),
            new ColorContainer(new Color32(0, 139, 139, 255), ConsoleColor.DarkCyan),
            new ColorContainer(new Color32(139, 0, 0, 255), ConsoleColor.DarkRed),
            new ColorContainer(new Color32(139, 0, 139, 255), ConsoleColor.DarkMagenta),
            new ColorContainer(new Color32(215, 195, 42, 255), ConsoleColor.DarkYellow),
            new ColorContainer(new Color32(128, 128, 128, 255), ConsoleColor.Gray),
            new ColorContainer(new Color32(169, 169, 169, 255), ConsoleColor.DarkGray),
            new ColorContainer(new Color32(0, 0, 255, 255), ConsoleColor.Blue),
            new ColorContainer(new Color32(0, 128, 0, 255), ConsoleColor.Green),
            new ColorContainer(new Color32(0, 255, 255, 255), ConsoleColor.Cyan),
            new ColorContainer(new Color32(255, 0, 0, 255), ConsoleColor.Red),
            new ColorContainer(new Color32(255, 0, 255, 255), ConsoleColor.Magenta),
            new ColorContainer(new Color32(255, 255, 0, 255), ConsoleColor.Yellow),
            new ColorContainer(new Color32(255, 255, 255, 255), ConsoleColor.White),
        };
        private static IEnumerable<ColorContainer> MixedColors => GenerateMixedColors();

        private static IEnumerable<ColorContainer> SortColorsByHue(this ColorContainer[] colors)
        {
            Array.Sort(colors, (firstColor, secondColor) => firstColor.Hue - secondColor.Hue);
            return colors;
        }
        

        private static IEnumerable<ColorContainer> GenerateMixedColors()
        {
            List<ColorContainer> __mixedColors = new List<ColorContainer>();
            foreach (ColorContainer __baseColor in _baseColors)
            {
                foreach (ColorContainer __otherBaseColor in _baseColors)
                {
                    Color __mix = Color.Lerp(__baseColor.Color, __otherBaseColor.Color, 0.5f);
                    ColorContainer __newColor = new ColorContainer(__mix, __baseColor.ForegroundColor, __otherBaseColor.ForegroundColor);
                    
                    bool __colorAlreadyExists = false;
                    foreach (ColorContainer __existingColor in __mixedColors.Where(existingColor => existingColor.Color == __newColor.Color)) __colorAlreadyExists = true;
                    foreach (ColorContainer __existingColor in _baseColors.Where(existingColor => existingColor.Color == __newColor.Color)) __colorAlreadyExists = true;
                    
                    if (!__colorAlreadyExists) __mixedColors.Add(__newColor);
                }
            }

            return __mixedColors;
        }
        
        private static IEnumerable<ColorContainer> GenerateMixedColorsFull()
        {
            List<ColorContainer> __mixedColors = new List<ColorContainer>();
            foreach (ColorContainer __baseColor in _baseColors)
            {
                foreach (ColorContainer __otherBaseColor in _baseColors)
                {
                    Color __mix = Color.Lerp(__baseColor.Color, __otherBaseColor.Color, 0.5f);
                    ColorContainer __newColor = new ColorContainer(__mix, __baseColor.ForegroundColor, __otherBaseColor.ForegroundColor);
                    
                    bool __colorAlreadyExists = false;
                    foreach (ColorContainer __existingColor in __mixedColors)
                    {
                        if (__newColor.ForegroundColor == __existingColor.ForegroundColor && __newColor.BackgroundColor == __existingColor.BackgroundColor)
                        {
                            __colorAlreadyExists = true;
                            break;
                        }

                        if (__newColor.ForegroundColor == __existingColor.BackgroundColor && __newColor.BackgroundColor == __existingColor.ForegroundColor)
                        {
                            __colorAlreadyExists = true;
                            break;
                        }
                    }
                    
                    if (!__colorAlreadyExists) __mixedColors.Add(__newColor);
                }
            }

            return __mixedColors;
        }
    }
}