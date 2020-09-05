using UnityEngine;

namespace Movement
{
    public class RotateTransform : MonoBehaviour, IRotate
    {
        [SerializeField] private float rotationSpeed;

        private Transform _transform;

        private Vector3 _rotation;
    
        void Awake()
        {
            _transform = transform;
        }

        void Update()
        {
            transform.localEulerAngles += Time.deltaTime * rotationSpeed * _rotation;
        }

        public void SetRotationVector(Vector3 eulerRotation)
        {
            _rotation = eulerRotation;
        }
    }
}
