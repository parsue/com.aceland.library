using System.Reflection;
using UnityEditor;

namespace AceLand.Library.Editor
{
public static class GameViewUtils
{
    private const string ASSEMBLY_NAME = "UnityEditor.dll";
    
    private static readonly object GameViewSizesInstance;
    private static readonly MethodInfo GetGroup;
 
    static GameViewUtils()
    {
        var sizesType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GameViewSizes");
        var singleType = typeof(ScriptableSingleton<>).MakeGenericType(sizesType);
        var instanceProp = singleType.GetProperty("instance");
        GetGroup = sizesType.GetMethod("GetGroup");
        GameViewSizesInstance = instanceProp?.GetValue(null, null);
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
        selectedSizeIndexProp?.SetValue(gvWnd, index, null);
    }
 
    public static void AddAndSelectCustomSize(GameViewSizeType viewSizeType, GameViewSizeGroupType sizeGroupType, int width, int height, string text)
    {
        AddCustomSize(viewSizeType, sizeGroupType, width, height, text);
        var idx = FindSize(GameViewSizeGroupType.Standalone, width, height);
        GameViewUtils.SetSize(idx);
    }
 
    public static void AddCustomSize(GameViewSizeType viewSizeType, GameViewSizeGroupType sizeGroupType, int width, int height, string text)
    {
        var group = GetGameViewGroup(sizeGroupType);
        var addCustomSize = GetGroup.ReturnType.GetMethod("AddCustomSize"); // or group.GetType().
        var assembly = Assembly.Load(ASSEMBLY_NAME);
        var gameViewSize = assembly.GetType("UnityEditor.GameViewSize");
        var gameViewSizeType = assembly.GetType("UnityEditor.GameViewSizeType");
        var ctor = gameViewSize.GetConstructor(new[]
            {
                 gameViewSizeType,
                 typeof(int),
                 typeof(int),
                 typeof(string)
            });
        var newSize = ctor!.Invoke(new object[] { (int)viewSizeType, width, height, text });
        addCustomSize?.Invoke(group, new object[] { newSize });
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
 
        var group = GetGameViewGroup(sizeGroupType);
        var getDisplayTexts = group.GetType().GetMethod("GetDisplayTexts");
        var displayTexts = getDisplayTexts!.Invoke(group, null) as string[];
        for (var i = 0; i < displayTexts?.Length; i++)
        {
            var display = displayTexts[i];
            // the text we get is "Name (W:H)" if the size has a name, or just "W:H" e.g. 16:9
            // so if we're querying a custom size text we sub-string to only get the name
            // You could see the outputs by just logging
            // Debug.Log(display);
            var pren = display.IndexOf('(');
            if (pren != -1)
                display = display[..(pren - 1)]; // -1 to remove the space that's before the pren. This is very implementation-dependent
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
 
        var group = GetGameViewGroup(sizeGroupType);
        var groupType = group.GetType();
        var getBuiltinCount = groupType.GetMethod("GetBuiltinCount");
        var getCustomCount = groupType.GetMethod("GetCustomCount");
        var sizesCount = (int)getBuiltinCount!.Invoke(group, null) + (int)getCustomCount!.Invoke(group, null);
        var getGameViewSize = groupType.GetMethod("GetGameViewSize");
        var gvsType = getGameViewSize?.ReturnType;
        var widthProp = gvsType?.GetProperty("width");
        var heightProp = gvsType?.GetProperty("height");
        var indexValue = new object[1];
        for (var i = 0; i < sizesCount; i++)
        {
            indexValue[0] = i;
            var size = getGameViewSize?.Invoke(group, indexValue);
            var sizeWidth = (int)widthProp!.GetValue(size, null);
            var sizeHeight = (int)heightProp!.GetValue(size, null);
            if (sizeWidth == width && sizeHeight == height)
                return i;
        }
        return -1;
    }

    private static object GetGameViewGroup(GameViewSizeGroupType type)
    {
        return GetGroup.Invoke(GameViewSizesInstance, new object[] { (int)type });
    }
    
    public static GameViewSizeGroupType GetCurrentGroupType()
    {
        var getCurrentGroupTypeProp = GameViewSizesInstance.GetType().GetProperty("currentGroupType");
        return (GameViewSizeGroupType)(int)getCurrentGroupTypeProp.GetValue(GameViewSizesInstance, null);
    }
}
}