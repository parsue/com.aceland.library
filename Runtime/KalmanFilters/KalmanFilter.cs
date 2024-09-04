using System;
using AceLand.Library.KalmanFilters.Core;

namespace AceLand.Library.KalmanFilters
{
    public static class KalmanFilter
    {
        public static KalmanFilterBuilder<T> Builder<T>() where T : unmanaged => new KalmanFilterBuilder<T>();
        public class KalmanFilterBuilder<T> where T : unmanaged
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

            public KalmanFilterBuilder<T> WithQ(float q)
            {
                _q = q;
                return this;
            }

            public KalmanFilterBuilder<T> WithR(float r)
            {
                _r = r;
                return this;
            }

            public KalmanFilterBuilder<T> WithP(float p)
            {
                _p = p;
                return this;
            }
        }
    }
}