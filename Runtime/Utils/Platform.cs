using UnityEngine;

namespace AceLand.Library.Utils
{
    public class Platform
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private void Info()
        {
#if UNITY_EDITOR
            Debug.Log($"Current Platform: {CurrentPlatform}");
#else
            Debug.Log($"[Platform]  : {CurrentPlatform}");
#endif
        }

        public string CurrentPlatform => Application.platform.ToString();
        public bool IsPlaying => Application.isPlaying;
        public bool IsEditor => Application.platform is RuntimePlatform.WindowsEditor or RuntimePlatform.OSXEditor or RuntimePlatform.LinuxEditor;
        public bool IsAndroid => Application.platform is RuntimePlatform.Android;
        public bool IsIphone => Application.platform is RuntimePlatform.IPhonePlayer;
        public bool IsMobile => IsAndroid || IsIphone;
        public bool IsPC => Application.platform is RuntimePlatform.WindowsEditor;
        public bool IsMac => Application.platform is RuntimePlatform.OSXPlayer;
        public bool IsLinux => Application.platform is RuntimePlatform.LinuxPlayer;
        public bool IsDesktop => IsPC || IsMac || IsLinux;
        public bool IsWebGL => Application.platform is RuntimePlatform.WebGLPlayer;
        public bool IsWinServer => Application.platform is RuntimePlatform.WindowsServer;
        public bool IsOSXServer => Application.platform is RuntimePlatform.OSXServer;
        public bool IsLinuxServer => Application.platform is RuntimePlatform.LinuxServer;
        public bool IsServer => IsWinServer || IsOSXServer || IsLinuxServer;
        public bool IsPS4 => Application.platform is RuntimePlatform.PS4;
        public bool IsPS5 => Application.platform is RuntimePlatform.PS5;
        public bool IsPS => IsPS4 || IsPS5;
        public bool IsSwitch => Application.platform is RuntimePlatform.Switch;
        public bool IsXboxOne => Application.platform is RuntimePlatform.XboxOne;
        public bool IsConsole => IsPS || IsSwitch || IsXboxOne;
        public bool IsAppleTV => Application.platform is RuntimePlatform.tvOS;
        public bool IsWSA_Arm => Application.platform is RuntimePlatform.WSAPlayerARM;
        public bool IsWSA_x64 => Application.platform is RuntimePlatform.WSAPlayerX64;
        public bool IsWSA_x86 => Application.platform is RuntimePlatform.WSAPlayerX86;
        public bool IsWindowsStoreApp => IsWSA_Arm || IsWSA_x64 || IsWSA_x86;
        //public bool IsStadia => Application.platform is RuntimePlatform.Stadia;
        //public bool IsLumin => Application.platform is RuntimePlatform.Lumin;
    }
}