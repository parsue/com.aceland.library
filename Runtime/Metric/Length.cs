namespace AceLand.Library.Metric
{
    public readonly struct Length
    {
        // Internal storage in meters
        internal Length(double meters) => this.meters = meters;
        private readonly double meters;

        // SI units
        public double Meters => meters;

        public double Kilometers => meters / 1_000.0;

        public double Centimeters => meters * 100.0;

        public double Millimeters => meters * 1_000.0;

        public double Micrometers => meters * 1_000_000.0;

        public double Nanometers => meters * 1_000_000_000.0;

        // Imperial / US customary
        // Exact: 1 inch = 0.0254 m (international inch)
        private const double METER_PER_INCH = 0.0254;
        private const double METER_PER_FOOT = 0.3048;          // 12 inches
        private const double METER_PER_YARD = 0.9144;          // 3 feet
        private const double METER_PER_MILE = 1_609.344;        // 1760 yards

        public double Inches => meters / METER_PER_INCH;

        public double Feet => meters / METER_PER_FOOT;

        public double Yards => meters / METER_PER_YARD;

        public double Miles => meters / METER_PER_MILE;

        // Nautical / astronomical
        private const double METER_PER_NAUTICAL_MILE = 1_852.0;  // exact
        private const double METER_PER_ASTRONOMICAL_UNIT = 149_597_870_700.0; // IAU 2012, exact

        public double NauticalMiles => meters / METER_PER_NAUTICAL_MILE;

        public double AstronomicalUnits => meters / METER_PER_ASTRONOMICAL_UNIT;

        // Convenience aliases (common spellings)
        public double Metres => Meters;

        public double Kilometres => Kilometers;

        public override string ToString() => $"{meters} meters";

        // Area operator remains unchanged
        public static Area operator *(Length width, Length breadth) =>
            (width.meters * breadth.meters).SquareMeters();
    }
}