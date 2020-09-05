using UnityEngine;

namespace Movement
{
    public class TurretMovement : MonoBehaviour
    {
        private IRotate _rotateController;
        private Camera _camera;
        private Transform _transform;

        void Awake()
        {
            _rotateController = GetComponent<IRotate>();
            _camera = Camera.main;
            _transform = transform;
        }

        void Update()
        {
            if (MouseToWorldPos(out Vector3 point))
            {
                transform.LookAt(point);
            }
        }

        bool MouseToWorldPos(out Vector3 worldPos)
        {
            Vector2 mousePos = Input.mousePosition;
            Ray screenRay = _camera.ScreenPointToRay(mousePos);
            Plane turretPlane = new Plane(Vector3.up, _transform.position);

            if (turretPlane.Raycast(screenRay, out float enter))
            {
                Vector3 point = screenRay.GetPoint(enter);
                worldPos = point;
                return true;
            }

            worldPos = Vector3.zero;
            return false;
        }

    }
}