using System;

namespace AceLand.Library.Extensions
{
    public static partial class Extensions
    {
        private static readonly string[] SIZE_SUFFIXES =
            { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        private static readonly string[] CURRENCY_SUFFIXES =
            { "", "K", "M", "B", "T", "Qa", "Qi", "Si", "Sp", "Oc", "N", "Dc", "Un", "Duo", "Tre", "Qua", "Qui", "SE", "SP", "OC", "NV", "VIG", "CE", "TRV", "QTU", "SPZ", "CJX", "XQR", "VNU", "YZQ", "KVZ", "JZW", "QZX", "ZKL", "HTZ", "RXV", "WZX", "XVC", "ZOL", "LXS", "YXZU", "JXKZ", "RTVX", "ZHGX", "QZQZ", "VZVZ" };

        public static string SizeSuffix(this long value, int decimalPlaces = 2)
        {
            if (decimalPlaces < 0)
                throw new ArgumentOutOfRangeException(nameof(decimalPlaces));
            
            switch (value)
            {
                case < 0:
                    return "-" + SizeSuffix(-value, decimalPlaces);
                case 0:
                    return string.Format("{0:n" + decimalPlaces + "} bytes", 0);
            }

            var mag = (int)Math.Log(value, 1024);
            var adjustedSize = (decimal)value / (1L << (mag * 10));

            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }
            
            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SIZE_SUFFIXES[Math.Min(mag, SIZE_SUFFIXES.Length - 1)]
            );
        }

        public static string CurrencySuffix(this long value, int decimalPlaces = 0)
        {
            if (decimalPlaces < 0)
                throw new ArgumentOutOfRangeException(nameof(decimalPlaces));
            
            switch (value)
            {
                case < 0:
                    return "-" + CurrencySuffix(-value, decimalPlaces);
                case < 1000:
                    return string.Format("{0:n" + 0 + "}", value);
            }

            var mag = (int)Math.Log(value, 1000);
            var adjustedSize = (decimal)value / (int)Math.Pow(1000, mag);

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize, 
                CURRENCY_SUFFIXES[Math.Min(mag, CURRENCY_SUFFIXES.Length - 1)]
            );
        }
    }
}
