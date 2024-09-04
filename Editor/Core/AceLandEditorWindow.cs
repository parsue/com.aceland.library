#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEditor.Build;

namespace AceLand.Editor.Core
{
    public class AceLandEditorWindow : EditorWindow
    {
        public enum TitleType { Main, Sub, }
        public enum Align { Left, Center, Right, }

        protected internal (int x, int y) margin = (10, 10);
        protected internal int posY, titleHeight;
        protected internal readonly int fieldHeight = 20, toggleSize = 15, lineMargin = 5;

        protected internal void AddDefineSymbols(params string[] symbols)
        {
            var targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
            var buildTarget = NamedBuildTarget.FromBuildTargetGroup(targetGroup);
            PlayerSettings.GetScriptingDefineSymbols(buildTarget, out var currentSymbols);
            var newSymbols = currentSymbols.ToList();
            newSymbols.AddRange(symbols);
            PlayerSettings.SetScriptingDefineSymbols(buildTarget, newSymbols.ToArray());
        }


        protected internal void DrawDiv(int heigth = 5, int reduceMargin = 0)
        {
            GUIStyle _style = new(EditorStyles.textField);
            posY += 10;
            GUI.Label(new Rect(margin.x + reduceMargin, posY, position.width - margin.x * 2 - reduceMargin * 2, heigth), " ", _style);
            posY += 18;
        }

        protected internal void EmptyLine()
        {
            posY += fieldHeight + lineMargin;
        }

        protected internal void NextLine()
        {
            posY += titleHeight + lineMargin;
        }

        protected internal void DrawTitle(string title, TitleType type = TitleType.Main)
        {
            GUIStyle _style = new(EditorStyles.textField);
            _style.normal.textColor = Color.white;
            switch (type)
            {
                case TitleType.Main:
                    _style.alignment = TextAnchor.MiddleCenter;
                    _style.fontSize = 20;
                    titleHeight = 30;
                    break;
                case TitleType.Sub:
                    _style.alignment = TextAnchor.MiddleCenter;
                    _style.fontSize = 14;
                    titleHeight = 26;
                    break;
            }
            GUI.Label(new Rect(margin.x, posY, position.width - margin.x * 2, titleHeight), title, _style);
            posY += titleHeight + lineMargin;
        }

        protected internal void DrawLabel(string text, Align align = Align.Left)
        {
            GUIStyle _style = new(EditorStyles.label)
            {
                richText = true
            };
            switch (align)
            {
                case Align.Left:
                    _style.alignment = TextAnchor.MiddleLeft;
                    break;
                case Align.Center:
                    _style.alignment = TextAnchor.MiddleCenter;
                    break;
                case Align.Right:
                    _style.alignment = TextAnchor.MiddleRight;
                    break;
            }
            GUI.Label(new Rect(margin.x, posY, position.width - margin.x * 2, fieldHeight), text, _style);
            posY += fieldHeight + lineMargin;
        }

        protected internal void DrawRedLabel(string text, Align align = Align.Left)
        {
            GUIStyle _style = new(EditorStyles.label)
            {
                richText = true
            };
            switch (align)
            {
                case Align.Left:
                    _style.alignment = TextAnchor.MiddleLeft;
                    break;
                case Align.Center:
                    _style.alignment = TextAnchor.MiddleCenter;
                    break;
                case Align.Right:
                    _style.alignment = TextAnchor.MiddleRight;
                    break;
            }
            GUI.Label(new Rect(margin.x, posY, position.width - margin.x * 2, fieldHeight), $"<color=red>{text}</color>", _style);
            posY += fieldHeight + lineMargin;
        }

        protected internal void DrawBigLabel(string text, int fontSize)
        {
            GUIStyle _style = new(EditorStyles.largeLabel)
            {
                fontSize = fontSize
            };
            GUI.Label(new Rect(margin.x, posY, position.width - margin.x * 2, fontSize * 1.5f), text, _style);
            posY += (int)(fontSize * 1.5f + lineMargin);
        }

        protected internal void DrawButton(string text, int btnWidth, System.Action action, bool adjPosY)
        {
            GUIStyle _style = new(EditorStyles.textField);
            var btnHeight = 24;
            _style.fontSize = 16;
            _style.alignment = TextAnchor.MiddleCenter;
            if (GUI.Button(new Rect((position.width - btnWidth) / 2, posY, btnWidth, btnHeight), text, _style))
                action();
            if (adjPosY)
                posY += btnHeight + lineMargin;
        }

        protected internal void DrawButton(Rect rect, string text, int btnHeight, GUIStyle style, System.Action onPress, bool adjPosY)
        {
            if (GUI.Button(rect, text, style))
                onPress?.Invoke();
            if (adjPosY)
                posY += btnHeight + lineMargin;
        }

        protected internal void DrawButton(string id, Rect rect, string text, int btnHeight, GUIStyle style, System.Action<string> onPress, bool adjPosY)
        {
            if (GUI.Button(rect, text, style))
                onPress?.Invoke(id);
            if (adjPosY)
                posY += btnHeight + lineMargin;
        }

        protected internal void DrawInt(ref int value, string text, int min, int max)
        {
            value = EditorGUI.IntSlider(new Rect(margin.x, posY, position.width - margin.x * 2, fieldHeight), text, value, min, max);
            posY += fieldHeight + lineMargin;
        }

        protected internal void DrawByte(ref byte value, string text, byte min, byte max)
        {
            value = (byte)EditorGUI.IntSlider(new Rect(margin.x, posY, position.width - margin.x * 2, fieldHeight), text, value, min, max);
            posY += fieldHeight + lineMargin;
        }

        protected internal void DrawFloat(ref float value, string text, float min, float max)
        {
            value = EditorGUI.Slider(new Rect(margin.x, posY, position.width - margin.x * 2, fieldHeight), text, value, min, max);
            posY += fieldHeight + lineMargin;
        }

        protected internal void DrawToggle(ref bool value, string text)
        {
            GUI.Label(new Rect(margin.x, posY, position.width - margin.x * 2 - toggleSize, fieldHeight), text);
            value = EditorGUI.Toggle(new Rect(position.width - margin.x - toggleSize, posY, toggleSize, fieldHeight), value);
            posY += fieldHeight + lineMargin;
        }

        protected internal void DrawText(ref string value, string text, int length = -1, bool noSpace = false, bool adjPosY = true)
        {
            EditorGUI.BeginChangeCheck();
            var input = EditorGUI.TextField(new Rect(margin.x, posY, position.width - margin.x * 2, fieldHeight), text, value);
            if (EditorGUI.EndChangeCheck())
            {
                if (noSpace) input = input.Replace(" ", "");
                if (length > 0 && input.Length > length) input = input[..length];
                value = input;
            }
            if (adjPosY)
                posY += fieldHeight + lineMargin;
        }

        protected internal void DrawText(string id, Rect rect, string text, bool noSpace = false, bool adjPosY = true, System.Action<string, string> onChange = null)
        {
            EditorGUI.BeginChangeCheck();
            var input = EditorGUI.TextField(rect, text);
            if (EditorGUI.EndChangeCheck())
            {
                if (noSpace) input = input.Replace(" ", "");
                onChange?.Invoke(id, input);
            }
            if (adjPosY)
                posY += (int)rect.height + lineMargin;

        }

        protected internal void DrawTextArea(string text, int fontSize, int heigth, bool wordWarp, TextAnchor alignment)
        {
            GUIStyle _style = new(EditorStyles.textField)
            {
                fontSize = fontSize,
                wordWrap = wordWarp,
                alignment = alignment
            };
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.TextArea(new Rect(margin.x, posY, position.width - margin.x * 2, heigth), text, _style);
            EditorGUI.EndDisabledGroup();
            posY += heigth + lineMargin;
        }

        protected internal void DrawPopup<T>(ref T value, string text) where T : System.Enum
        {
            value = (T)EditorGUI.EnumPopup(new Rect(margin.x, posY, position.width - margin.x * 2, fieldHeight), text, value);
            posY += fieldHeight + lineMargin;
        }
    }
}
#endif
