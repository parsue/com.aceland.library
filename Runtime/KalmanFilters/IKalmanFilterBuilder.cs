namespace AceLand.Library.KalmanFilters
{
    public interface IKalmanFilterBuilder<T> where T : unmanaged
    {
        IKalmanFilter<T> Build();
        IKalmanFilterBuilder<T> WithQ(float processNoise);
        IKalmanFilterBuilder<T> WithR(float observationNoise);
        IKalmanFilterBuilder<T> WithP(float lastPrediction);
    }
}