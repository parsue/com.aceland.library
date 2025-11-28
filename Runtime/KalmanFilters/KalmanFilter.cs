using AceLand.Library.KalmanFilters.Builders;

namespace AceLand.Library.KalmanFilters
{
    public static class KalmanFilter
    {
        public static IKalmanFilterBuilder<T> Builder<T>() where T : unmanaged =>
            new KalmanFilterBuilder<T>();
    }
}