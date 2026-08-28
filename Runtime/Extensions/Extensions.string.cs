namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value) =>
            string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }
}
