using System;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static string GetOwnerName<T>(this T action) where T : Delegate
        {
            return action.Target == null
                ? action.Method.DeclaringType.FullName.Split('`')[0].Split('.')[^1]
                : action.Target.GetType().FullName.Split('`')[0].Split('.')[^1];
        }
    }
}