using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace AceLand.Library.Editor.AudioHandlers
{
    public static class AudioPreviewer
    {
#if UNITY_6000_4_OR_NEWER
        private static EntityId? _lastPlayedAudioClipId = null;
#else
        private static int? _lastPlayedAudioClipId = null;
#endif

        [OnOpenAsset]
#if UNITY_6000_4_OR_NEWER
        public static bool OnOpenAsset(EntityId entityId)
#else
        public static bool OnOpenAsset(int instanceId, int line)
#endif
        {
#if UNITY_6000_4_OR_NEWER
            var obj = EditorUtility.EntityIdToObject(entityId);
#else
            var obj = EditorUtility.InstanceIDToObject(instanceId);
#endif
            if (obj is not AudioClip audioClip) return false;
            if (IsPreviewClipPlaying())
            {
                StopAllPreviewClips();
#if UNITY_6000_4_OR_NEWER
                if (_lastPlayedAudioClipId.HasValue && _lastPlayedAudioClipId.Value != audioClip.GetEntityId())
#else
                if (_lastPlayedAudioClipId.HasValue && _lastPlayedAudioClipId.Value != audioClip.GetInstanceID())
#endif
                    PlayPreviewClip(audioClip);
            }
            else
            {
                PlayPreviewClip(audioClip);
            }
            
#if UNITY_6000_4_OR_NEWER
            _lastPlayedAudioClipId = audioClip.GetEntityId();
#else
            _lastPlayedAudioClipId = audioClip.GetInstanceID();
#endif
            
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
