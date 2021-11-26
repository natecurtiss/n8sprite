using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace N8Sprite
{
    public static class ColorGenerator
    {
        static bool _hasInitializedAllColors;
        static IEnumerable<ColorContainer> _allColors;
        static readonly ColorContainer[] _baseColors =
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
            new ColorContainer(new Color32(255, 255, 255, 255), ConsoleColor.White)
        };
        
        internal static IEnumerable<ColorContainer> AllColors
        {
            get
            {
                if (_hasInitializedAllColors)
                    return _allColors;
                _hasInitializedAllColors = true;
                _allColors = _baseColors.Concat(GenerateMixedColors()).ToArray().SortColorsByHue();
                return _allColors;
            }
        }

        public static ColorContainer MatchToColorContainer(this Color color)
        {
            foreach (var colorContainer in AllColors)
                if (colorContainer.Color == color) return colorContainer;
            return new ColorContainer(Color.clear, ConsoleColor.Black);
        }
        
        static IEnumerable<ColorContainer> SortColorsByHue(this ColorContainer[] colors)
        {
            Array.Sort(colors, (firstColor, secondColor) => firstColor.Hue - secondColor.Hue);
            return colors;
        }
        
        static IEnumerable<ColorContainer> GenerateMixedColors()
        {
            var mixedColors = new List<ColorContainer>();
            foreach (var baseColor in _baseColors)
            {
                foreach (var otherBaseColor in _baseColors)
                {
                    var mixedColor = Color32.Lerp(baseColor.Color, otherBaseColor.Color, 0.5f);
                    var newColor = new ColorContainer(mixedColor, baseColor.ForegroundColor, otherBaseColor.ForegroundColor);

                    var colorAlreadyExists = false;
                    foreach (var _ in mixedColors.Where
                        (existingColor => existingColor.Color.IsEqualTo(newColor.Color))) colorAlreadyExists = true;
                    foreach (var _ in _baseColors.Where
                        (existingColor => existingColor.Color.IsEqualTo(newColor.Color))) colorAlreadyExists = true;

                    if (!colorAlreadyExists) mixedColors.Add(newColor);
                }
            }
            return mixedColors;
        }
        
        static IEnumerable<ColorContainer> GenerateMixedColorsFull()
        {
            var mixedColors = new List<ColorContainer>();
            foreach (var baseColor in _baseColors)
            {
                foreach (var otherBaseColor in _baseColors)
                {
                    var mixedColor = Color32.Lerp(baseColor.Color, otherBaseColor.Color, 0.5f);
                    var newColor = new ColorContainer(mixedColor, baseColor.ForegroundColor, otherBaseColor.ForegroundColor);

                    var colorAlreadyExists = false;
                    foreach (var existingColor in mixedColors)
                    {
                        if (newColor.ForegroundColor == existingColor.ForegroundColor && newColor.BackgroundColor == existingColor.BackgroundColor)
                        {
                            colorAlreadyExists = true;
                            break;
                        }

                        if (newColor.ForegroundColor == existingColor.BackgroundColor && newColor.BackgroundColor == existingColor.ForegroundColor)
                        {
                            colorAlreadyExists = true;
                            break;
                        }
                    }
                    if (!colorAlreadyExists) mixedColors.Add(newColor);
                }
            }

            return mixedColors;
        }
    }
}