using System;
using UnityEngine;

namespace GameCamera
{
    public class MoveCameraInterpolate : MonoBehaviour, IMoveCamera
    {
        [SerializeField] private float interpolationSpeed = 10f;
        
        private Vector3 _targetPreviousPosition = Vector3.zero;
        
        private Transform _transform;
        private Transform _targetTransform;

        private Vector3 _leftDelta;
        
        void Awake()
        {
            _transform = transform;
        }
        
        void FixedUpdate()
        {
            Vector3 targetDeltaMove = _targetTransform.position - _targetPreviousPosition;
            _targetPreviousPosition = _targetTransform.position;
            
            Vector3 position = transform.position;
            Vector3 newPosition = Vector3.Lerp(position, position + targetDeltaMove + _leftDelta,
                interpolationSpeed * Time.deltaTime);

            _leftDelta += targetDeltaMove - (newPosition - position);
            transform.position = newPosition;
        }
        
        public void SetTarget(Transform target)
        {
            _targetPreviousPosition = target.position;
            Vector3 cameraOffset = _transform.position;
            _transform.position = _targetPreviousPosition + cameraOffset;

            _targetTransform = target;
        }
    }
}
