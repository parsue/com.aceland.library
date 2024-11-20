using System;
using AceLand.Library.KalmanFilters.Core;

namespace AceLand.Library.KalmanFilters
{
    public static class KalmanFilter
    {
        public static IKalmanFilterBuilder<T> Builder<T>() where T : unmanaged => new KalmanFilterBuilder<T>();
        
        public interface IKalmanFilterBuilder<T> where T : unmanaged
        {
            IKalmanFilter<T> Build();
            IKalmanFilterBuilder<T> WithQ(float processNoise);
            IKalmanFilterBuilder<T> WithR(float observationNoise);
            IKalmanFilterBuilder<T> WithP(float lastPrediction);
        }
        private class KalmanFilterBuilder<T> : IKalmanFilterBuilder<T>
            where T : unmanaged
        {
            private float _q = 0.000001f;
            private float _r = 0.001f;
            private float _p = 1f;
            
            public IKalmanFilter<T> Build()
            {
                var type = typeof(T).Name;
                var kalmanFilter = type switch
                {
                    "Single" => new KalmanFilterFloat(_q, _r, _p) as IKalmanFilter<T>,
                    "Vector2" => new KalmanFilterVector2(_q, _r, _p) as IKalmanFilter<T>,
                    "Vector3" => new KalmanFilterVector3(_q, _r, _p) as IKalmanFilter<T>,
                    "Vector4" => new KalmanFilterVector4(_q, _r, _p) as IKalmanFilter<T>,
                    _ => throw new ArgumentOutOfRangeException($"KalmanFilterBuilder error: ", type, "not supported type"),
                };

                return kalmanFilter;
            }

            public IKalmanFilterBuilder<T> WithQ(float processNoise)
            {
                _q = processNoise;
                return this;
            }

            public IKalmanFilterBuilder<T> WithR(float observationNoise)
            {
                _r = observationNoise;
                return this;
            }

            public IKalmanFilterBuilder<T> WithP(float lastPrediction)
            {
                _p = lastPrediction;
                return this;
            }
        }
    }
}