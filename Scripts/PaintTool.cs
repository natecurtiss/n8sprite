using UnityEngine;

namespace N8Sprite
{
    public sealed class PaintTool : MonoBehaviour
    {
        [SerializeField] 
        private Tool ThisTool;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
                CanvasOptions.SelectedTool = Tool.Brush;
            else if (Input.GetKeyDown(KeyCode.E))
                CanvasOptions.SelectedTool = Tool.Eraser;
        }

        public void ChangeTool() => CanvasOptions.SelectedTool = ThisTool;
    }
    
    public enum Tool { Brush, Eraser }
}