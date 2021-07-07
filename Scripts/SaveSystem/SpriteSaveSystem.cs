using System.IO;
using AnotherFileBrowser.Windows;
using UnityEditor;
using UnityEngine;

namespace N8Sprite.SaveSystem
{
    public static class SpriteSaveSystem
    {
        public static void Save(Texture2D texture)
        {
            int __numberOfLines = CanvasData.Size;
            int __numberOfPixelsInEachLine = CanvasData.Size;
            Vector2Int __startingPixel = new Vector2Int
            (
                texture.width / 2 - __numberOfPixelsInEachLine / 2,
                texture.height / 2 - __numberOfLines / 2
            );
            string __fileData = string.Empty;
            for (int __line = 0; __line < __numberOfLines; __line++)
            {
                for (int __pixel = 0; __pixel < __numberOfPixelsInEachLine; __pixel++)
                {
                    Vector2Int __currentPixel = __startingPixel + new Vector2Int(__pixel, __line);
                    Color __pixelColor = texture.GetPixel(__currentPixel.x, __currentPixel.y);
                    ColorContainer __pixelColorAsColorContainer = __pixelColor.MatchToColorContainer();
                    string __foregroundColor = __pixelColorAsColorContainer.ForegroundColor.ToString();
                    string __backgroundColor = __pixelColorAsColorContainer.BackgroundColor.ToString();
                    if (__pixelColorAsColorContainer.Color == Color.clear)
                    {
                        __foregroundColor = "Clear";
                        __backgroundColor = "Clear";
                    }
                    __fileData += $"{{{__foregroundColor},{__backgroundColor}}}";
                }
                __fileData += "\n";
            }

            BrowserProperties __browserProperties = new BrowserProperties
            {
                Filter = "n8sprite files (*.n8sprite)|*.n8sprite", 
                FilterIndex = 0
            };
            new FileBrowser().SaveFileBrowser
            (
                __browserProperties, 
                "NewSprite", 
                ".n8sprite",
                path => File.WriteAllText(path, __fileData)
            );
        }
    }
}