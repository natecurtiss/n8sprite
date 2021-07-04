using System;
using UnityEngine;

namespace N8Sprite
{
    [RequireComponent(typeof(Animator))]
    public sealed class PaintTool : MonoBehaviour
    {
        private static event Action<Tool> OnToolChanged;
        
        [SerializeField] 
        private Tool ThisTool;
        
        [SerializeField]
        private string SelectedAnimatorBoolean = "Selected";
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            OnToolChanged += ToolChanged;
        }

        private void OnDestroy() => OnToolChanged -= ToolChanged;

        private void Start() => OnToolChanged?.Invoke(Tool.Brush);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                CanvasOptions.SelectedTool = Tool.Brush;
                OnToolChanged?.Invoke(Tool.Brush);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                CanvasOptions.SelectedTool = Tool.Eraser;
                OnToolChanged?.Invoke(Tool.Eraser);
            }
        }

        public void ChangeTool()
        {
            CanvasOptions.SelectedTool = ThisTool;
            OnToolChanged?.Invoke(ThisTool);
        }

        private void ToolChanged(Tool tool) => _animator.SetBool(SelectedAnimatorBoolean, tool == ThisTool);
    }
    
    public enum Tool { Brush, Eraser }
}