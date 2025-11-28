using System;
using AceLand.Library.KalmanFilters.Core;

namespace AceLand.Library.KalmanFilters.Builders
{
    internal class KalmanFilterBuilder<T> : IKalmanFilterBuilder<T>
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
                "Single" => KalmanFilterFloat.Build(_q, _r, _p) as IKalmanFilter<T>,
                "Vector2" => KalmanFilterVector2.Build(_q, _r, _p) as IKalmanFilter<T>,
                "Vector3" => KalmanFilterVector3.Build(_q, _r, _p) as IKalmanFilter<T>,
                "Vector4" => KalmanFilterVector4.Build(_q, _r, _p) as IKalmanFilter<T>,
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