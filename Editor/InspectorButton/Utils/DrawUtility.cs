namespace AceLand.Library.Editor.InspectorButton.Utils
{
    using System;
    using UnityEditor;
    using UnityEngine;

    internal static class DrawUtility
    {
        private static readonly GUIContent _tempContent = new GUIContent();

        public readonly struct VerticalIndent : IDisposable
        {
            private const float SpacingHeight = 10f;
            private readonly bool _bottom;

            public VerticalIndent(bool top, bool bottom)
            {
                if (top)
                    GUILayout.Space(SpacingHeight);

                _bottom = bottom;
            }

            public void Dispose()
            {
                if (_bottom)
                    GUILayout.Space(SpacingHeight);
            }
        }

        public static bool DrawInFoldout(Rect foldoutRect, bool expanded, string header, Action drawStuff)
        {
            expanded = EditorGUI.BeginFoldoutHeaderGroup(foldoutRect, expanded, header);

            if (expanded)
            {
                EditorGUI.indentLevel++;
                drawStuff();
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.EndFoldoutHeaderGroup();

            return expanded;
        }

        public static (Rect foldoutRect, Rect buttonRect) GetFoldoutAndButtonRects(string header)
        {
            const float buttonWidth = 60f;

            Rect _foldoutWithoutButton = GUILayoutUtility.GetRect(TempContent(header), EditorStyles.foldoutHeader);

            var foldoutRect = new Rect(
                _foldoutWithoutButton.x,
                _foldoutWithoutButton.y,
                _foldoutWithoutButton.width - buttonWidth,
                _foldoutWithoutButton.height);

            var buttonRect = new Rect(
                _foldoutWithoutButton.xMax - buttonWidth,
                _foldoutWithoutButton.y,
                buttonWidth,
                _foldoutWithoutButton.height);

            return (foldoutRect, buttonRect);
        }

        private static GUIContent TempContent(string text)
        {
            _tempContent.text = text;
            return _tempContent;
        }
    }
}