using System.IO;
using UnityEngine;

namespace N8Sprite
{
    public static class SpriteSaveSystem
    {
        public static void Save(Texture2D texture)
        {
            var numberOfLines = CanvasData.Size;
            var numberOfPixelsInEachLine = CanvasData.Size;
            var startingPixel = new Vector2Int
            (
                texture.width / 2 - numberOfPixelsInEachLine / 2,
                texture.height / 2 - numberOfLines / 2
            );
            var fileData = string.Empty;
            for (var line = 0; line < numberOfLines; line++)
            {
                for (var pixel = 0; pixel < numberOfPixelsInEachLine; pixel++)
                {
                    var currentPixel = startingPixel + new Vector2Int(pixel, line);
                    var pixelColor = texture.GetPixel(currentPixel.x, currentPixel.y);
                    var pixelColorAsColorContainer = pixelColor.MatchToColorContainer();
                    var foregroundColor = pixelColorAsColorContainer.ForegroundColor.ToString();
                    var backgroundColor = pixelColorAsColorContainer.BackgroundColor.ToString();
                    if (pixelColorAsColorContainer.Color == Color.clear)
                    {
                        foregroundColor = "Clear";
                        backgroundColor = "Clear";
                    }
                    fileData += $"{{{foregroundColor},{backgroundColor}}}";
                }
                fileData += "\n";
            }
            File.WriteAllText($"{Application.dataPath}/test.n8sprite", fileData);
        }
    }
}