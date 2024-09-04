#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.Windows;
using UnityEditor.Build;
using System.Linq;

namespace AceLand.Editor.Core
{
    public class EditorFunctions
    {
        public static string SystemAssetsRoot = string.Concat(System.Environment.CurrentDirectory, "/Assets/");
        public static string AceLandDocumentSystemRoot = string.Concat(System.Environment.CurrentDirectory, "/Assets/AceLand/Document/");

        public static bool IsAceLandDocumentExist(string filename) => File.Exists(string.Concat(AceLandDocumentSystemRoot, filename));

        private static readonly List<NamedBuildTarget> IGNORE_BUILD_TARGETS = new()
        {
            NamedBuildTarget.Standalone,
            NamedBuildTarget.Android,
            NamedBuildTarget.iOS,
            NamedBuildTarget.WebGL,
            NamedBuildTarget.WindowsStoreApps,
        };

        public static IEnumerable<(NamedBuildTarget buildTarget, List<string> symbols)> AllBuildTargets()
        {
            foreach (var buildTarget in IGNORE_BUILD_TARGETS)
            {
                PlayerSettings.GetScriptingDefineSymbols(buildTarget, out var symbols);
                yield return (buildTarget, symbols.ToList());
            }
        }

        public static bool OpenAceLandDocument(string filename)
        {
            if (IsAceLandDocumentExist(filename))
            {
                Application.OpenURL(string.Concat(AceLandDocumentSystemRoot, filename));
                return true;
            }
            return false;
        }

        public static void OpenSite(string site) => Application.OpenURL(site);

        public static List<T> FindAssetsByType<T>() where T : Object
        {
            List<T> _assets = new();
            var _guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof(T)));
            for (var i = 0; i < _guids.Length; i++)
            {
                var _assetPath = AssetDatabase.GUIDToAssetPath(_guids[i]);
                var _asset = AssetDatabase.LoadAssetAtPath<T>(_assetPath);
                if (_asset != null)
                    _assets.Add(_asset);
            }
            return _assets;
        }

        public static T CreateScriptableObject<T>(string savePath, string fileName) where T : ScriptableObject
        {
            var _asset = ScriptableObject.CreateInstance<T>();

            var _assetPathAndName = string.Concat("Assets/", savePath, "/", fileName, ".asset");
            var _folders = savePath.Split('/');
            var _parentFolder = "Assets";
            for (var i = 0; i < _folders.Length; i++)
            {
                var _folder = string.Concat(_parentFolder, "/", _folders[i]);
                if (!AssetDatabase.IsValidFolder(_folder))
                    AssetDatabase.CreateFolder(_parentFolder, _folders[i]);
                _parentFolder = _folder;
            }
            AssetDatabase.CreateAsset(_asset, _assetPathAndName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = _asset;

            return _asset;
        }
    }
}
#endif
