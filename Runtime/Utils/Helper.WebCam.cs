using UnityEngine;

namespace AceLand.Library.Utils
{
    public partial class Helper
    {        
        public int WebCamCount => WebCamTexture.devices.Length;
        public bool HasWebCam => WebCamCount > 0;
        
        public bool TryGetWebCam(int camId, int width, int height, int fps, out WebCamDevice webCamDevice, out WebCamTexture webCamTexture)
        {
            if (!HasWebCam)
            {
                webCamDevice = default;
                webCamTexture = default;
                return false;
            }
            
            webCamDevice = WebCamTexture.devices[camId];
            webCamTexture = new WebCamTexture(webCamDevice.name, width, height, fps);
            return true;
        }

        public bool TryGetFrontCam(int width, int height, int fps, out WebCamDevice webCamDevice, out WebCamTexture webCamTexture)
        {
#if UNITY_ANDROID
            return GetFrontCam(width, height, fps, out webCamDevice, out webCamTexture);
#elif UNITY_IPHONE
            return GetFrontCam(width, height, fps, out webCamDevice, out webCamTexture);
#else
            return TryGetWebCam(0, width, height, fps, out webCamDevice, out webCamTexture);
#endif
        }

        private bool GetFrontCam(int width, int height, int fps, out WebCamDevice webCamDevice, out WebCamTexture webCamTexture)
        {
            var devices = WebCamTexture.devices;

            foreach (var device in devices)
            {
                if (!device.isFrontFacing) continue;
                webCamDevice = device;
                webCamTexture = new WebCamTexture(device.name, width, height, fps);
                return true;
            }

            webCamDevice = default;
            webCamTexture = default;
            return false;
        }
    }
}