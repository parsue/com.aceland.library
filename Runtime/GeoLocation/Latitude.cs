namespace AceLand.Library.GeoLocation
{
    public readonly struct Latitude
    {
        private Latitude(double degrees)
        {
            this.degrees = degrees;
        }
        
        public static Latitude Degrees(double degrees) =>
            degrees < -90.0 ? new Latitude(-90.0)
            : degrees > 90.0 ? new Latitude(90.0)
            : new Latitude(degrees);
        public static Latitude North(double degrees) =>
            degrees < 0.0 ? new Latitude(0.0)
            : degrees > 90.0 ? new Latitude(90.0)
            : new Latitude(degrees);
        public static Latitude South(double degrees) =>
            degrees < 0.0 ? new Latitude(0.0)
            : degrees > 90.0 ? new Latitude(-90.0)
            : new Latitude(-degrees);
        
        private readonly double degrees;
        
        public double Value => degrees;
        public override string ToString() => $"{System.Math.Abs(degrees)}° {(degrees >=0 ? "N": "S")}";
    }
}