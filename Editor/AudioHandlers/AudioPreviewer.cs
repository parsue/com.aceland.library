using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AceLand.Library.Editor.AudioHandlers
{
    public static class AudioPreviewer
    {
        private static int? _lastPlayedAudioClipId = null;

        [OnOpenAsset]
        public static bool OnOpenAsset(int instanceId, int line)
        {
#if UNITY_6000_3_OR_NEWER
            var obj = EditorUtility.EntityIdToObject(instanceId);
#else
            var obj = EditorUtility.InstanceIDToObject(instanceId);
#endif
            if (obj is not AudioClip audioClip) return false;
            if (IsPreviewClipPlaying())
            {
                StopAllPreviewClips();
                if (_lastPlayedAudioClipId.HasValue && _lastPlayedAudioClipId.Value != audioClip.GetInstanceID())
                    PlayPreviewClip(audioClip);
            }
            else
            {
                PlayPreviewClip(audioClip);
            }
            _lastPlayedAudioClipId = audioClip.GetInstanceID();
            return true;
        }

        public static void PlayPreviewClip(AudioClip audioClip)
        {
            var unityAssembly = typeof(AudioImporter).Assembly;
            var audioUtil = unityAssembly.GetType("UnityEditor.AudioUtil");
            var methodInfo = audioUtil.GetMethod(
                "PlayPreviewClip", 
                BindingFlags.Static | BindingFlags.Public, 
                null, 
                new Type[] {typeof(AudioClip), typeof(Int32), typeof(Boolean)},
                null
            );
            if (methodInfo == null) return;
            methodInfo.Invoke(null, new object[] { audioClip, 0, false });
        }

        public static bool IsPreviewClipPlaying()
        {
            var unityAssembly = typeof(AudioImporter).Assembly;
            var audioUtil = unityAssembly.GetType("UnityEditor.AudioUtil");
            var methodInfo = audioUtil.GetMethod(
                "IsPreviewClipPlaying",
                BindingFlags.Static | BindingFlags.Public
            );
            if (methodInfo == null) return false;
            return (bool)methodInfo.Invoke(null, null);
        }

        public static void StopAllPreviewClips()
        {
            var unityAssembly = typeof(AudioImporter).Assembly;
            var audioUtil = unityAssembly.GetType("UnityEditor.AudioUtil");
            var methodInfo = audioUtil.GetMethod(
                "StopAllPreviewClips",
                BindingFlags.Static | BindingFlags.Public
            );
            if (methodInfo == null) return;
            methodInfo.Invoke(null, null);
        }
    }
}
