using System.Collections.Generic;
using System.Numerics;

namespace AceLand.Library.KalmanFilters.Core
{
	public class KalmanFilterVector4 : KalmanFilterBase<Vector4>
	{
		internal KalmanFilterVector4(float q, float r, float p) : base(q, r, p) { }

		public override Vector4 Update(Vector4 measurement, float? newQ = null, float? newR = null) {

			// update values if supplied.
			if (newQ != null && Q != newQ) {
				Q = (float)newQ;
			}
			if (newR != null && R != newR) {
				R = (float)newR;
			}
			
			// update measurement.
			{
				K = (P + Q) / (P + Q + R);
				P = R * (P + Q) / (R + P + Q);
			}

			// filter result back into calculation.
			var result = X + (measurement - X) * K;
			X = result;
			return result;
		}

		public override Vector4 Update(List<Vector4> measurements, bool areMeasurementsNewestFirst = false, float? newQ = null, float? newR = null) {

			var result = Vector4.Zero;
			var i = (areMeasurementsNewestFirst) ? measurements.Count - 1 : 0;

			while (i < measurements.Count && i >= 0) {

				// decrement or increment the counter.
				if (areMeasurementsNewestFirst) {
					--i;
				}
				else {
					++i;
				}

				result = Update(measurements[i], newQ, newR);
			}

			return result;
		}
	}
}