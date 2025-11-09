namespace AceLand.Library.GeoLocation
{
    public readonly struct Wgs84Location
    {
        public Wgs84Location(Latitude latitude, Longitude longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
        
        private readonly Latitude latitude;
        private readonly Longitude longitude;
        
        public double Latitude => latitude.Value;
        public double Longitude => longitude.Value;
        public override string ToString() => $"({latitude}, {longitude})";
    }
}