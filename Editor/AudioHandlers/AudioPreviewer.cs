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
        private static int? ms_lastPlayedAudioClipId = null;

        [OnOpenAsset]
        public static bool OnOpenAsset(int instanceId, int line)
        {
            Object obj = EditorUtility.InstanceIDToObject(instanceId);
            if (obj is not AudioClip audioClip) return false;
            if (IsPreviewClipPlaying())
            {
                StopAllPreviewClips();
                if (ms_lastPlayedAudioClipId.HasValue && ms_lastPlayedAudioClipId.Value != audioClip.GetInstanceID())
                    PlayPreviewClip(audioClip);
            }
            else
            {
                PlayPreviewClip(audioClip);
            }
            ms_lastPlayedAudioClipId = audioClip.GetInstanceID();
            return true;
        }

        public static void PlayPreviewClip(AudioClip audioClip)
        {
            Assembly unityAssembly = typeof(AudioImporter).Assembly;
            Type audioUtil = unityAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo methodInfo = audioUtil.GetMethod(
                "PlayPreviewClip", 
                BindingFlags.Static | BindingFlags.Public, 
                null, 
                new Type[] {typeof(AudioClip), typeof(Int32), typeof(Boolean)},
                null
            );
            methodInfo.Invoke(null, new object[] { audioClip, 0, false });
        }

        public static bool IsPreviewClipPlaying()
        {
            Assembly unityAssembly = typeof(AudioImporter).Assembly;
            Type audioUtil = unityAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo methodInfo = audioUtil.GetMethod(
                "IsPreviewClipPlaying",
                BindingFlags.Static | BindingFlags.Public
            );
            return (bool)methodInfo.Invoke(null, null);
        }

        public static void StopAllPreviewClips()
        {
            Assembly unityAssembly = typeof(AudioImporter).Assembly;
            Type audioUtil = unityAssembly.GetType("UnityEditor.AudioUtil");
            MethodInfo methodInfo = audioUtil.GetMethod(
                "StopAllPreviewClips",
                BindingFlags.Static | BindingFlags.Public
            );
            methodInfo.Invoke(null, null);
        }
    }
}
