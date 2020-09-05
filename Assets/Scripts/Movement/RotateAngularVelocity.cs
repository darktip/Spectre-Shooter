using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class RotateAngularVelocity : MonoBehaviour, IRotate
    {
        [SerializeField] private float rotationSpeed;

        private Rigidbody _rigidbody;

        private Vector3 _rotation;
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            _rigidbody.angularVelocity = rotationSpeed * _rotation;
        }
    
        public void SetRotationVector(Vector3 eulerRotation)
        {
            _rotation = eulerRotation;
        }
    }
}
