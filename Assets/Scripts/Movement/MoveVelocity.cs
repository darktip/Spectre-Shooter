using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveVelocity : MonoBehaviour, IMove
    {
        [SerializeField] private float moveSpeed;
    
        private Rigidbody _rigidbody;
    
        private Vector3 _moveVector;
    
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            _rigidbody.velocity = _moveVector * moveSpeed;
        }

        public void SetMoveVector(Vector3 vector)
        {
            _moveVector = vector;
        }
    }
}
