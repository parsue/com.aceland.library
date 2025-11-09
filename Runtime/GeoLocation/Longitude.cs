namespace AceLand.Library.GeoLocation
{
    public readonly struct Longitude
    {
        private Longitude(double degrees)
        {
            this.degrees = degrees;
        }
        
        public static Longitude Degrees(double degrees) =>
            degrees < -180.0 ? new Longitude(-180.0)
            : degrees > 180.0 ? new Longitude(180.0)
            : new Longitude(degrees);
        public static Longitude East(double degrees) =>
            degrees < 0.0 ? new Longitude(0.0)
            : degrees > 180.0 ? new Longitude(180.0)
            : new Longitude(degrees);
        public static Longitude West(double degrees) =>
            degrees < 0.0 ? new Longitude(0.0)
            : degrees > 180.0 ? new Longitude(-180.0)
            : new Longitude(-degrees);
        
        private readonly double degrees;
        
        public double Value => degrees;
        public override string ToString() => $"{System.Math.Abs(degrees)}° {(degrees >=0 ? "E": "W")}";
    }
}