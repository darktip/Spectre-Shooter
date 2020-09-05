using GameInput;
using UnityEngine;

namespace Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private IMove _moveController;
        private IRotate _rotateController;
        private Transform _transform;
    
        private void Awake()
        {
            _moveController = GetComponent<IMove>();
            _rotateController = GetComponent<IRotate>();
            _transform = transform;
        }

        private void Update()
        {
            Vector2 moveAxis = Vector2.zero;

            if (InputManager.Instance.Input.MoveForward())
                moveAxis.y = 1f;
            else if (InputManager.Instance.Input.MoveBackwards())
                moveAxis.y = -1f;
            if (InputManager.Instance.Input.SteerLeft())
                moveAxis.x = -1f;
            else if (InputManager.Instance.Input.SteerRight())
                moveAxis.x = 1f;

            _moveController?.SetMoveVector((transform.forward * moveAxis.y).normalized);
            _rotateController?.SetRotationVector(new Vector3(0, moveAxis.x, 0));
        }
    }
}
