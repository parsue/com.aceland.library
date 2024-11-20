using System;
using UnityEditor;
using UnityEngine;

namespace AceLand.Library.Editor.InspectorButton.Utils
{
    internal static class DrawUtility
    {
        private static readonly GUIContent TEMP_CONTENT = new GUIContent();

        public readonly struct VerticalIndent : IDisposable
        {
            private const float SPACING_HEIGHT = 10f;
            private readonly bool _bottom;

            public VerticalIndent(bool top, bool bottom)
            {
                if (top)
                    GUILayout.Space(SPACING_HEIGHT);

                _bottom = bottom;
            }

            public void Dispose()
            {
                if (_bottom)
                    GUILayout.Space(SPACING_HEIGHT);
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

            var foldoutWithoutButton = GUILayoutUtility.GetRect(TempContent(header), EditorStyles.foldoutHeader);

            var foldoutRect = new Rect(
                foldoutWithoutButton.x,
                foldoutWithoutButton.y,
                foldoutWithoutButton.width - buttonWidth,
                foldoutWithoutButton.height);

            var buttonRect = new Rect(
                foldoutWithoutButton.xMax - buttonWidth,
                foldoutWithoutButton.y,
                buttonWidth,
                foldoutWithoutButton.height);

            return (foldoutRect, buttonRect);
        }

        private static GUIContent TempContent(string text)
        {
            TEMP_CONTENT.text = text;
            return TEMP_CONTENT;
        }
    }
}