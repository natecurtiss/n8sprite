using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace N8Sprite
{
    /// <summary>
    /// Contains properties for generating combinations of <see cref="ConsoleColor">ConsoleColors.</see>
    /// </summary>
    public static class ColorGenerator
    {
        /// <summary>
        /// True when <see cref="AllColors" /> has been assigned (to prevent calling
        /// <see cref="AllColors">AllColors'</see> expensive getter more than once).
        /// </summary>
        private static bool _hasInitializedAllColors;
        /// <summary>
        /// Backing field for <see cref="AllColors" />.
        /// </summary>
        private static IEnumerable<ColorContainer> _allColors;
        /// <summary>
        /// All 16 of the base <see cref="ConsoleColor">ConsoleColors.</see>
        /// </summary>
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
            new ColorContainer(new Color32(255, 255, 255, 255), ConsoleColor.White)
        };
        
        /// <summary>
        /// All of the possible <see cref="ConsoleColor" /> combinations.
        /// </summary>
        public static IEnumerable<ColorContainer> AllColors
        {
            get
            {
                if (_hasInitializedAllColors)
                    return _allColors;
                _hasInitializedAllColors = true;
                _allColors = _baseColors.Concat(MixedColors).ToArray().SortColorsByHue();
                return _allColors;
            }
        }
        
        /// <summary>
        /// All of the possible mixes of the 16 <see cref="_baseColors" />.
        /// </summary>
        private static IEnumerable<ColorContainer> MixedColors => GenerateMixedColors();

        /// <summary>
        /// Returns a <see cref="ColorContainer"/> that matches the <see cref="Color"/> passed in.
        /// </summary>
        /// <param name="color"> The <see cref="Color"/> to match. </param>
        public static ColorContainer MatchToColorContainer(this Color color)
        {
            foreach (var colorContainer in AllColors)
                if (colorContainer.Color == color) return colorContainer;
            return new ColorContainer(Color.clear, ConsoleColor.Black);
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{ColorContainer}"/> of <see cref="ColorContainer">ColorContainers</see>
        /// sorted by <see cref="ColorContainer.Hue"/>.
        /// </summary>
        /// <param name="colors"> The array of <see cref="ColorContainer">ColorContainers</see> to sort. </param>
        private static IEnumerable<ColorContainer> SortColorsByHue(this ColorContainer[] colors)
        {
            Array.Sort(colors, (firstColor, secondColor) => firstColor.Hue - secondColor.Hue);
            return colors;
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{ColorContainer}" /> of all 130 possible combinations of the
        /// <see cref="_baseColors" />, which includes the <see cref="_baseColors" />, and is without any duplicates
        /// (<see cref="ConsoleColor.Black" /> + <see cref="ConsoleColor.White" /> == <see cref="ConsoleColor.Gray" />).
        /// </summary>
        private static IEnumerable<ColorContainer> GenerateMixedColors()
        {
            var mixedColors = new List<ColorContainer>();
            foreach (var baseColor in _baseColors)
            {
                foreach (var otherBaseColor in _baseColors)
                {
                    var mixedColor = Color32.Lerp(baseColor.Color, otherBaseColor.Color, 0.5f);
                    var newColor = new ColorContainer(mixedColor, baseColor.ForegroundColor, otherBaseColor.ForegroundColor);

                    var colorAlreadyExists = false;
                    foreach (var existingColor in mixedColors.Where(existingColor => existingColor.Color.IsEqualTo(newColor.Color))) colorAlreadyExists = true;
                    foreach (var existingColor in _baseColors.Where(existingColor => existingColor.Color.IsEqualTo(newColor.Color))) colorAlreadyExists = true;

                    if (!colorAlreadyExists) mixedColors.Add(newColor);
                }
            }

            return mixedColors;
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{ColorContainer}" /> of all 136 possible combinations of the
        /// <see cref="_baseColors" />, which includes the <see cref="_baseColors" />, and is with the 6 duplicates
        /// (<see cref="ConsoleColor.Black" /> + <see cref="ConsoleColor.White" /> == <see cref="ConsoleColor.Gray" />).
        /// </summary>
        private static IEnumerable<ColorContainer> GenerateMixedColorsFull()
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