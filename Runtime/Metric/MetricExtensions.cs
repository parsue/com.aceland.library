namespace AceLand.Library.Metric
{
    public static class MetricExtensions
    {
        // Length (double)
        public static Length Kilometers(this double value) => new(value * 1_000.0);
        public static Length Meters(this double value) => new(value);
        public static Length Centimeters(this double value) => new(value / 100.0);
        public static Length Millimeters(this double value) => new(value / 1_000.0);
        public static Length Micrometers(this double value) => new(value / 1_000_000.0);
        public static Length Nanometers(this double value) => new(value / 1_000_000_000.0);

        public static Length Inches(this double value) => new(value * 0.0254);
        public static Length Feet(this double value) => new(value * 0.3048);
        public static Length Yards(this double value) => new(value * 0.9144);
        public static Length Miles(this double value) => new(value * 1_609.344);
        public static Length NauticalMiles(this double value) => new(value * 1_852.0);

        // Length (int)
        public static Length Kilometers(this int value) => new(value * 1_000.0);
        public static Length Meters(this int value) => new(value);
        public static Length Centimeters(this int value) => new(value / 100.0);
        public static Length Millimeters(this int value) => new(value / 1_000.0);
        public static Length Micrometers(this int value) => new(value / 1_000_000.0);
        public static Length Nanometers(this int value) => new(value / 1_000_000_000.0);

        public static Length Inches(this int value) => new(value * 0.0254);
        public static Length Feet(this int value) => new(value * 0.3048);
        public static Length Yards(this int value) => new(value * 0.9144);
        public static Length Miles(this int value) => new(value * 1_609.344);
        public static Length NauticalMiles(this int value) => new(value * 1_852.0);

        // Area (double)
        public static Area SquareKilometers(this double value) => new(value * 1_000_000.0);
        public static Area SquareMeters(this double value) => new(value);
        public static Area SquareCentimeters(this double value) => new(value / 10_000.0);
        public static Area SquareMillimeters(this double value) => new(value / 1_000_000.0);
        public static Area SquareMicrometers(this double value) => new(value / 1_000_000_000_000.0);
        public static Area SquareNanometers(this double value) => new(value / 1_000_000_000_000_000_000.0);

        public static Area SquareInches(this double value) => new(value * 0.00064516);      // 1 in² = 0.00064516 m²
        public static Area SquareFeet(this double value) => new(value * 0.09290304);       // 1 ft² = 0.09290304 m²
        public static Area SquareYards(this double value) => new(value * 0.83612736);      // 1 yd² = 0.83612736 m²
        public static Area SquareMiles(this double value) => new(value * 2_589_988.110336);// 1 mi² = 2,589,988.110336 m²
        public static Area SquareNauticalMiles(this double value) => new(value * 3_429_904.0); // 1 nmi² = (1852 m)²

        public static Area Acres(this double value) => new(value * 4_046.8564224);         // 1 acre = 4046.8564224 m²
        public static Area Ares(this double value) => new(value * 100.0);                  // 1 are = 100 m²
        public static Area Hectares(this double value) => new(value * 10_000.0);           // 1 ha = 10,000 m²
    }
}