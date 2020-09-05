using UnityEngine;

namespace Movement
{
    public class MoveTransform : MonoBehaviour, IMove
    {
        [SerializeField] private float moveSpeed;
    
        private Vector3 _moveVector;

        private Transform _transform;
    
        void Awake()
        {
            _transform = transform;
        }

        void Update()
        {
            transform.position += Time.deltaTime * moveSpeed * _moveVector;
        }

        public void SetMoveVector(Vector3 vector)
        {
            _moveVector = vector;
        }
    }
}
