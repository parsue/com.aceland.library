using UnityEngine;

namespace AceLand.Library.Utils
{
    public static class Platform
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void Info()
        {
#if UNITY_EDITOR
            Debug.Log($"Current Platform: {CurrentPlatform}");
#else
            Debug.Log($"[Platform]  : {CurrentPlatform}");
#endif
        }

        public static string CurrentPlatform => Application.platform.ToString();
        public static bool IsPlaying => Application.isPlaying;
        public static bool IsEditor => Application.platform is RuntimePlatform.WindowsEditor or RuntimePlatform.OSXEditor or RuntimePlatform.LinuxEditor;
        public static bool IsAndroid => Application.platform is RuntimePlatform.Android;
        public static bool IsIphone => Application.platform is RuntimePlatform.IPhonePlayer;
        public static bool IsMobile => IsAndroid || IsIphone;
        public static bool IsPC => Application.platform is RuntimePlatform.WindowsEditor;
        public static bool IsMac => Application.platform is RuntimePlatform.OSXPlayer;
        public static bool IsLinux => Application.platform is RuntimePlatform.LinuxPlayer;
        public static bool IsDesktop => IsPC || IsMac || IsLinux;
        public static bool IsWebGL => Application.platform is RuntimePlatform.WebGLPlayer;
        public static bool IsWinServer => Application.platform is RuntimePlatform.WindowsServer;
        public static bool IsOSXServer => Application.platform is RuntimePlatform.OSXServer;
        public static bool IsLinuxServer => Application.platform is RuntimePlatform.LinuxServer;
        public static bool IsServer => IsWinServer || IsOSXServer || IsLinuxServer;
        public static bool IsPS4 => Application.platform is RuntimePlatform.PS4;
        public static bool IsPS5 => Application.platform is RuntimePlatform.PS5;
        public static bool IsPS => IsPS4 || IsPS5;
        public static bool IsSwitch => Application.platform is RuntimePlatform.Switch;
        public static bool IsXboxOne => Application.platform is RuntimePlatform.XboxOne;
        public static bool IsConsole => IsPS || IsSwitch || IsXboxOne;
        public static bool IsAppleTV => Application.platform is RuntimePlatform.tvOS;
        public static bool IsWSA_Arm => Application.platform is RuntimePlatform.WSAPlayerARM;
        public static bool IsWSA_x64 => Application.platform is RuntimePlatform.WSAPlayerX64;
        public static bool IsWSA_x86 => Application.platform is RuntimePlatform.WSAPlayerX86;
        public static bool IsWindowsStoreApp => IsWSA_Arm || IsWSA_x64 || IsWSA_x86;
        //public static bool IsStadia => Application.platform is RuntimePlatform.Stadia;
        //public static bool IsLumin => Application.platform is RuntimePlatform.Lumin;
    }
}