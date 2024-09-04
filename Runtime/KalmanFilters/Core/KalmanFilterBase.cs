using System.Collections.Generic;

namespace AceLand.Library.KalmanFilters.Core
{
    public abstract class KalmanFilterBase<T> : IKalmanFilter<T>
        where T : unmanaged
    {
        private protected float Q;  // the covariance of the process noise, default 0.000001
        private protected float R;  // the covariance of the observation noise, default 0.001
        private protected float P;  // last prediction with R
        private protected float K;  // last prediction
        private protected T X;      // last result

        internal KalmanFilterBase(float q, float r, float p)
        {
            Q = q;
            R = r;
            P = p;
        }

        public (T x, float p, float k) GetCurrentValues()
        {
            return (X, P, K);
        }

        public void SetValues(T x, float p, float k)
        {
            X = x;
            P = p;
            K = k;
        }

        public virtual T Update(T measurement, float? newQ = null, float? newR = null)
        {
            return default;
        }

        public virtual T Update(List<T> measurements, bool areMeasurementsNewestFirst = false, float? newQ = null, float? newR = null)
        {
            return default;
        }

        public virtual void Reset()
        {
            P = 1;
            X = default;
            K = 0;
        }
    }
}