using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace N8Sprite
{
    [RequireComponent(typeof(Animator))]
    sealed class PaintTool : MonoBehaviour
    {
        static event Action<Tool> OnToolChanged;

        [SerializeField] 
        Tool _thisTool;
        [SerializeField] 
        string _selectedAnimatorBool = "Selected";

        Animator _animator;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            OnToolChanged += ToolChanged;
        }

        void Start() => OnToolChanged?.Invoke(Tool.Brush);

        void OnDestroy() => OnToolChanged -= ToolChanged;

        void Update()
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

        void ToolChanged(Tool tool) => _animator.SetBool(_selectedAnimatorBool, tool == _thisTool);
    }

    enum Tool
    {
        Brush,
        Eraser
    }
}