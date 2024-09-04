using System;
using System.Reflection;
using UnityEditor;

namespace AceLand.Library.Editor
{
public static class GameViewUtils
{
    private static readonly object _gameViewSizesInstance;
    private static readonly MethodInfo _getGroup;
 
    static GameViewUtils()
    {
        // gameViewSizesInstance  = ScriptableSingleton<GameViewSizes>.instance;
        var sizesType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GameViewSizes");
        var singleType = typeof(ScriptableSingleton<>).MakeGenericType(sizesType);
        var instanceProp = singleType.GetProperty("instance");
        _getGroup = sizesType.GetMethod("GetGroup");
        _gameViewSizesInstance = instanceProp.GetValue(null, null);
    }
 
    public enum GameViewSizeType
    {
        AspectRatio, FixedResolution
    }
 
    public static void SetSize(int index)
    {
        var gvWndType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GameView");
        var selectedSizeIndexProp = gvWndType.GetProperty("selectedSizeIndex",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        var gvWnd = EditorWindow.GetWindow(gvWndType);
        selectedSizeIndexProp.SetValue(gvWnd, index, null);
    }
 
    public static void AddAndSelectCustomSize(GameViewSizeType viewSizeType, GameViewSizeGroupType sizeGroupType, int width, int height, string text)
    {
        AddCustomSize(viewSizeType, sizeGroupType, width, height, text);
        var idx = GameViewUtils.FindSize(GameViewSizeGroupType.Standalone, width, height);
        GameViewUtils.SetSize(idx);
    }
 
    public static void AddCustomSize(GameViewSizeType viewSizeType, GameViewSizeGroupType sizeGroupType, int width, int height, string text)
    {
        var group = GetGroup(sizeGroupType);
        var addCustomSize = _getGroup.ReturnType.GetMethod("AddCustomSize"); // or group.GetType().
        var gvsType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GameViewSize");
        var assemblyName = "UnityEditor.dll";
        var assembly = Assembly.Load(assemblyName);
        var gameViewSize = assembly.GetType("UnityEditor.GameViewSize");
        var gameViewSizeType = assembly.GetType("UnityEditor.GameViewSizeType");
        var ctor = gameViewSize.GetConstructor(new Type[]
            {
                 gameViewSizeType,
                 typeof(int),
                 typeof(int),
                 typeof(string)
            });
        var newSize = ctor.Invoke(new object[] { (int)viewSizeType, width, height, text });
        addCustomSize.Invoke(group, new object[] { newSize });
    }
 
    public static bool SizeExists(GameViewSizeGroupType sizeGroupType, string text)
    {
        return FindSize(sizeGroupType, text) != -1;
    }
 
    public static int FindSize(GameViewSizeGroupType sizeGroupType, string text)
    {
        // GameViewSizes group = gameViewSizesInstance.GetGroup(sizeGroupType);
        // string[] texts = group.GetDisplayTexts();
        // for loop...
 
        var group = GetGroup(sizeGroupType);
        var getDisplayTexts = group.GetType().GetMethod("GetDisplayTexts");
        var displayTexts = getDisplayTexts.Invoke(group, null) as string[];
        for (var i = 0; i < displayTexts.Length; i++)
        {
            var display = displayTexts[i];
            // the text we get is "Name (W:H)" if the size has a name, or just "W:H" e.g. 16:9
            // so if we're querying a custom size text we substring to only get the name
            // You could see the outputs by just logging
            // Debug.Log(display);
            var pren = display.IndexOf('(');
            if (pren != -1)
                display = display.Substring(0, pren - 1); // -1 to remove the space that's before the prens. This is very implementation-depdenent
            if (display == text)
                return i;
        }
        return -1;
    }
 
    public static bool SizeExists(GameViewSizeGroupType sizeGroupType, int width, int height)
    {
        return FindSize(sizeGroupType, width, height) != -1;
    }
 
    public static int FindSize(GameViewSizeGroupType sizeGroupType, int width, int height)
    {
        // goal:
        // GameViewSizes group = gameViewSizesInstance.GetGroup(sizeGroupType);
        // int sizesCount = group.GetBuiltinCount() + group.GetCustomCount();
        // iterate through the sizes via group.GetGameViewSize(int index)
 
        var group = GetGroup(sizeGroupType);
        var groupType = group.GetType();
        var getBuiltinCount = groupType.GetMethod("GetBuiltinCount");
        var getCustomCount = groupType.GetMethod("GetCustomCount");
        var sizesCount = (int)getBuiltinCount.Invoke(group, null) + (int)getCustomCount.Invoke(group, null);
        var getGameViewSize = groupType.GetMethod("GetGameViewSize");
        var gvsType = getGameViewSize.ReturnType;
        var widthProp = gvsType.GetProperty("width");
        var heightProp = gvsType.GetProperty("height");
        var indexValue = new object[1];
        for (var i = 0; i < sizesCount; i++)
        {
            indexValue[0] = i;
            var size = getGameViewSize.Invoke(group, indexValue);
            var sizeWidth = (int)widthProp.GetValue(size, null);
            var sizeHeight = (int)heightProp.GetValue(size, null);
            if (sizeWidth == width && sizeHeight == height)
                return i;
        }
        return -1;
    }

    private static object GetGroup(GameViewSizeGroupType type)
    {
        return _getGroup.Invoke(_gameViewSizesInstance, new object[] { (int)type });
    }
    
    public static GameViewSizeGroupType GetCurrentGroupType()
    {
        var getCurrentGroupTypeProp = _gameViewSizesInstance.GetType().GetProperty("currentGroupType");
        return (GameViewSizeGroupType)(int)getCurrentGroupTypeProp.GetValue(_gameViewSizesInstance, null);
    }
}
}