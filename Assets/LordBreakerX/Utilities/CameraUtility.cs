using UnityEngine;

namespace LordBreakerX.Utilities
{
    public static class CameraUtility
    {
        private static Camera _camera;

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            SetCamera(Camera.main);
        }

        public static void SetCamera(Camera camera)
        {
            if (camera != null)
            {
                _camera = camera;
            }
        }

        public static Camera GetCamera()
        {
            if (_camera == null)
            {
                _camera = Camera.main;
            }

            return _camera;
        }

        public static void SwitchCamera(Camera camera)
        {
            if (camera != null)
            {
                if (_camera != null)
                {
                    _camera.gameObject.SetActive(false);
                }
                SetCamera(camera);

                _camera.gameObject.SetActive(true);
            }
        }
    }
}
