namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        public static string SizeSuffix(this short value, int decimalPlaces = 2) =>
            ((long)value).SizeSuffix(decimalPlaces);

        public static string CurrencySuffix(this short value, int decimalPlaces = 0) =>
            ((long)value).CurrencySuffix(decimalPlaces);
    }
}
