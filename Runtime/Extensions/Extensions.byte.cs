namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static string SizeSuffix(this byte value, int decimalPlaces = 2) =>
            ((long)value).SizeSuffix(decimalPlaces);

        public static string CurrencySuffix(this byte value, int decimalPlaces = 0) =>
            ((long)value).CurrencySuffix(decimalPlaces);
    }
}
