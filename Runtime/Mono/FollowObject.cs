using AceLand.Library.Attribute;
using UnityEngine;
using UnityEngine.Serialization;

namespace AceLand.Library.Mono
{
    [ExecuteInEditMode]
    [AddComponentMenu("AMVR/Tool/Follow Object")]
    public class FollowObject : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Transform target;
        [SerializeField] private float smoothTime = 0.2f;

        [Header("Ignore Axis")]
        [SerializeField] private bool ignoreX;
        [SerializeField] private bool ignoreY;
        [SerializeField] private bool ignoreZ;

        [Header("Offset")]
        [SerializeField] private bool setOffset;
        [SerializeField, ConditionalShow("setOffset")] private Vector3 offset;

        [Header("Range")]
        [SerializeField] private bool setRange;
        [SerializeField, ConditionalShow("setRange")] private Vector2 rangeX;
        [SerializeField, ConditionalShow("setRange")] private Vector2 rangeY;
        [SerializeField, ConditionalShow("setRange")] private Vector2 rangeZ;

        private bool Active => target != null;

        private Transform _transform;
        private Vector3 _targetPosition;
        private Vector3 _velocity = Vector3.zero;

        public void OnValidate()
        {
            CheckRange(ref rangeX);
            CheckRange(ref rangeY);
            CheckRange(ref rangeZ);
        }

        private void Awake()
        {
            _transform = transform;
        }

        private void CheckRange(ref Vector2 value)
        {
            if (value.x <= value.y) return;
            value.x = Mathf.Min(value.x, value.y);
            value.y = Mathf.Max(value.x, value.y);
        }

        private void LateUpdate()
        {
            if (!Active) return;
            _targetPosition.x = ignoreX ? _transform.position.x : target.position.x;
            _targetPosition.y = ignoreY ? _transform.position.y : target.position.y;
            _targetPosition.z = ignoreZ ? _transform.position.z : target.position.z;
            SetRange();
            SetOffset();
            _transform.position = Vector3.SmoothDamp(_transform.position, _targetPosition, ref _velocity, smoothTime);
        }

        private void SetRange()
        {
            if (!setRange) return;
            if (!ignoreX) _targetPosition.x = Mathf.Clamp(_targetPosition.x, rangeX.x, rangeX.y);
            if (!ignoreY) _targetPosition.y = Mathf.Clamp(_targetPosition.y, rangeY.x, rangeY.y);
            if (!ignoreZ) _targetPosition.z = Mathf.Clamp(_targetPosition.z, rangeZ.x, rangeZ.y);
        }

        private void SetOffset()
        {
            if (!setOffset) return;
            _targetPosition += offset;
        }

        public void SetTarget(Transform newTarget) => this.target = newTarget;

#if UNITY_EDITOR
        [Header("Debug")]
        [SerializeField] private bool drawDebugLine;
        [FormerlySerializedAs("_lineColor")] [SerializeField] private Color lineColor = Color.red;
        private void OnDrawGizmosSelected()
        {
            if (!drawDebugLine || !setRange) return;

            Vector3 center, size;
            center.x = rangeX.x + rangeX.y;
            center.x *= 0.5f;
            center.y = rangeY.x + rangeY.y;
            center.y *= 0.5f;
            center.z = rangeZ.x + rangeZ.y;
            center.z *= 0.5f;
            size.x = rangeX.y - rangeX.x;
            size.y = rangeY.y - rangeY.x;
            size.z = rangeZ.y - rangeZ.x;

            Gizmos.color = lineColor;
            Gizmos.DrawWireCube(center, size);
        }
#endif
    }
}