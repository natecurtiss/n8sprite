using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace N8Sprite.Events
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class EventManager
    {
        public static readonly Event<Vector2Int> OnCanvasResolutionChanged = new Event<Vector2Int>();
    }
}