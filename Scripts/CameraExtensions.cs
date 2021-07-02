using UnityEngine;

namespace N8Sprite
{
    public static class CameraExtensions
    {
        public static Camera MainCamera
        {
            get
            {
                if (!_mainCamera)
                    _mainCamera = Camera.main;
                return _mainCamera;
            }
        }
        private static Camera _mainCamera;

        public static Vector3 ScreenToWorld(this Camera camera, Vector3 screenPosition)
        {
            screenPosition.z = MainCamera.nearClipPlane;
            return camera.ScreenToWorldPoint(screenPosition);
        }
    }
}