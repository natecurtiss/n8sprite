using UnityEngine;

namespace N8Sprite
{
    public sealed class PaintTools : MonoBehaviour
    {
        public static Tool SelectedTool = Tool.Brush;
        [SerializeField] private Tool ThisTool;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
                SelectedTool = Tool.Brush;
            else if (Input.GetKeyDown(KeyCode.E))
                SelectedTool = Tool.Eraser;
        }

        public void ChangeTool() => SelectedTool = ThisTool;
    }
    
    public enum Tool { Brush, Eraser }
}