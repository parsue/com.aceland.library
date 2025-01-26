namespace AceLand.Library.BuildLeveling
{
    public static class BuildLevelExtensions
    {
        public static bool IsAcceptedLevel(this BuildLevel level)
        {
            if (level == BuildLevel.None) return false;
#if UNITY_EDITOR
            return level >= BuildLevel.Editor;
#elif DEBUG
            return level >= BuildLevel.Development;
#else
            return level >= BuildLevel.Production;
#endif
        }

        public static bool IsAcceptedLevelInvert(this BuildLevel level)
        {
            if (level == BuildLevel.None) return false;
#if UNITY_EDITOR
            return level <= BuildLevel.Editor;
#elif DEBUG
            return level <= BuildLevel.Development;
#else
            return level <= BuildLevel.Production;
#endif
        }

        public static bool IsAcceptedLevelOnly(this BuildLevel level)
        {
            if (level == BuildLevel.None) return false;
#if UNITY_EDITOR
            return level == BuildLevel.Editor;
#elif DEBUG
            return level == BuildLevel.Development;
#else
            return level == BuildLevel.Production;
#endif
        }
    }
}