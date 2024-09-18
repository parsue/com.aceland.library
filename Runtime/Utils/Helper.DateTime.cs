using System;

namespace AceLand.Library.Utils
{
    public static partial class Helper
    {
        internal static DateTime StartUpTime;

        public static double RealtimeSinceStartup =>
            (DateTime.Now - StartUpTime).TotalSeconds;
    }
}