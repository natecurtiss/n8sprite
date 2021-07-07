using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace N8Sprite
{
    [RequireComponent(typeof(Animator))]
    internal sealed class PaintTool : MonoBehaviour
    {
        private static event Action<Tool> OnToolChanged;

        [SerializeField]
        private Tool _thisTool;
        [SerializeField]
        private string _selectedAnimatorBool = "Selected";
        
        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            OnToolChanged += ToolChanged;
        }
        
        private void Start() => OnToolChanged?.Invoke(Tool.Brush);

        private void OnDestroy() => OnToolChanged -= ToolChanged;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                CanvasData.SelectedTool = Tool.Brush;
                OnToolChanged?.Invoke(Tool.Brush);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                CanvasData.SelectedTool = Tool.Eraser;
                OnToolChanged?.Invoke(Tool.Eraser);
            }
        }
        
        public void ChangeTool()
        {
            CanvasData.SelectedTool = _thisTool;
            OnToolChanged?.Invoke(_thisTool);
        }

        private void ToolChanged(Tool tool) => _animator.SetBool(_selectedAnimatorBool, tool == _thisTool);
    }

    internal enum Tool
    {
        Brush,
        Eraser
    }
}