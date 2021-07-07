﻿using UnityEngine;
using UnityEngine.UI;

namespace N8Sprite
{
    [RequireComponent(typeof(Image))]
    internal sealed class ColorImage : MonoBehaviour
    {
        private ColorContainer _color;
        private Image _image;

        public ColorContainer Color
        {
            set
            {
                _image.color = value.Color;
                _color = value;
            }
        }

        private void Awake() => _image = GetComponent<Image>();

        public void ChangeSelectedColor() => CanvasData.SelectedColor = _color.Color;
    }
}