namespace AceLand.Library.BuildLeveling
{
    public static class BuildLevelUtils
    {
        public static BuildLevel CurrentLevel
        {
            get
            {
#if UNITY_EDITOR
                return BuildLevel.Editor;
#elif DEBUG
                return BuildLevel.Development;
#else
                return BuildLevel.Production;
#endif
            }
        }
    }
}