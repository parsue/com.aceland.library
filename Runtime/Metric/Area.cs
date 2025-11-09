namespace AceLand.Library.Metric
{
    public readonly struct Area
    {
        // Internal storage in square meters
        internal Area(double squareMeters) => this.squareMeters = squareMeters;
        private readonly double squareMeters;

        // Base SI
        public double SquareMeters => squareMeters;

        // SI multiples/submultiples
        public double SquareKilometers => squareMeters / 1_000_000.0; // 1 km² = 1,000,000 m²

        public double SquareCentimeters => squareMeters * 10_000.0; // 1 m² = 10,000 cm²

        public double SquareMillimeters => squareMeters * 1_000_000.0; // 1 m² = 1,000,000 mm²

        public double SquareMicrometers => squareMeters * 1_000_000_000_000.0; // 1 m² = 10^12 μm²

        public double SquareNanometers => squareMeters * 1_000_000_000_000_000_000.0; // 1 m² = 10^18 nm²

        // Hectare / Are
        public double Hectares => squareMeters / 10_000.0; // 1 ha = 10,000 m²

        public double Ares => squareMeters / 100.0; // 1 a = 100 m²

        // Imperial / US customary (based on exact inch definition)
        private const double METER_PER_INCH = 0.0254;              // exact
        private const double METER_PER_FOOT = 0.3048;              // 12 inches
        private const double METER_PER_YARD = 0.9144;              // 3 feet
        private const double METER_PER_MILE = 1_609.344;            // 1760 yards

        private const double SQUARE_METER_PER_SQUARE_INCH = METER_PER_INCH * METER_PER_INCH;   // 0.00064516 m²
        private const double SQUARE_METER_PER_SQUARE_FOOT = METER_PER_FOOT * METER_PER_FOOT;   // 0.09290304 m²
        private const double SQUARE_METER_PER_SQUARE_YARD = METER_PER_YARD * METER_PER_YARD;   // 0.83612736 m²
        private const double SQUARE_METER_PER_SQUARE_MILE = METER_PER_MILE * METER_PER_MILE;   // 2,589,988.110336 m²

        public double SquareInches => squareMeters / SQUARE_METER_PER_SQUARE_INCH;

        public double SquareFeet => squareMeters / SQUARE_METER_PER_SQUARE_FOOT;

        public double SquareYards => squareMeters / SQUARE_METER_PER_SQUARE_YARD;

        public double SquareMiles => squareMeters / SQUARE_METER_PER_SQUARE_MILE;

        // Nautical square miles
        private const double METER_PER_NAUTICAL_MILE = 1_852.0;      // exact
        private const double SQUARE_METER_PER_SQUARE_NAUTICAL_MILE = METER_PER_NAUTICAL_MILE * METER_PER_NAUTICAL_MILE; // 3,429,904 m²

        public double SquareNauticalMiles => squareMeters / SQUARE_METER_PER_SQUARE_NAUTICAL_MILE;

        // Acres
        // 1 international acre = 43,560 ft² = 4046.8564224 m² (exact from inch definition)
        private const double SQUARE_METER_PER_ACRE = 4_046.8564224;

        public double Acres => squareMeters / SQUARE_METER_PER_ACRE;

        // Aliases (spelling variants)
        public double SquareMetres => SquareMeters;

        public double SquareKilometres => SquareKilometers;

        public override string ToString() => $"{squareMeters} m²";
    }
}