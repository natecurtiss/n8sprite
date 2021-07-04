﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace N8Sprite
{
    [RequireComponent(typeof(Image))]
    public sealed class CurrentColor : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 1f)]
        private float AnimationDuration = 0.1f;
        
        private Image _image;
        private Color _targetColor;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _targetColor = CanvasOptions.SelectedColor;
        }

        private void Update()
        {
            if (CanvasOptions.SelectedColor == Color.clear) return;
            if (CanvasOptions.SelectedColor != _targetColor)
            {
                _image.DOKill();
                _targetColor = CanvasOptions.SelectedColor;
                _image.DOColor(_targetColor, AnimationDuration);
            }
        }
    }
}