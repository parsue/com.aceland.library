using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AceLand.Library.Editor
{
    public static class EditorHelper
    {
        public static string SystemAssetsRoot = string.Concat(System.Environment.CurrentDirectory, "/Assets/");

        public static List<T> FindAssetsByType<T>() where T : Object
        {
            List<T> assets = new();
            var guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof(T)));
            foreach (var t in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(t);
                var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                if (asset != null)
                    assets.Add(asset);
            }
            return assets;
        }

        public static T CreateScriptableObject<T>(string savePath, string fileName) where T : ScriptableObject
        {
            var asset = ScriptableObject.CreateInstance<T>();

            var assetPathAndName = string.Concat("Assets/", savePath, "/", fileName, ".asset");
            var folders = savePath.Split('/');
            var parentFolder = "Assets";
            foreach (var t in folders)
            {
                var folder = string.Concat(parentFolder, "/", t);
                if (!AssetDatabase.IsValidFolder(folder))
                    AssetDatabase.CreateFolder(parentFolder, t);
                parentFolder = folder;
            }
            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;

            return asset;
        }
        
        public static GameObject CreateEmptyInHierarchy(string name)
        {
            return new GameObject()
            {
                name = name,
                transform =
                {
                    parent = null,
                    position = Vector3.zero,
                    rotation = Quaternion.identity,
                    localScale = Vector3.one,
                }
            };
        }
        
        public static GameObject CreateAndRename(string startingName)
        {
            GameObject gameObject = new(startingName);
            Transform transform = gameObject.transform;
            if (Selection.activeGameObject)
            {
                transform.parent = Selection.activeGameObject.transform;
                transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            }
            Selection.activeGameObject = gameObject;
            Undo.RegisterCreatedObjectUndo(gameObject, $"Created Game Object [{startingName}]");
            EditorApplication.delayCall += () =>
            {
                Type sceneHierarchyType = Type.GetType("UnityEditor.SceneHierarchyWindow,UnityEditor");
                EditorWindow.GetWindow(sceneHierarchyType).SendEvent(EditorGUIUtility.CommandEvent("Rename"));
            };
            return gameObject;
        }
        
        public static void DrawAllProperties(SerializedObject settings, bool includeScript = false)
        {
            var iterator = settings.GetIterator();
            iterator.NextVisible(true);
            
            do
            {
                var name = iterator.name;
                if (!includeScript && name == "m_Script") continue;
                EditorGUILayout.PropertyField(settings.FindProperty(name));
            } while (iterator.NextVisible(false));
            
            settings.ApplyModifiedPropertiesWithoutUndo();
        }
        
        public static void DrawAllPropertiesAsDisabled(SerializedObject settings, bool includeScript = true)
        {
            EditorGUI.BeginDisabledGroup(true);
            DrawAllProperties(settings, includeScript);
            EditorGUI.EndDisabledGroup();
        }
    }
}