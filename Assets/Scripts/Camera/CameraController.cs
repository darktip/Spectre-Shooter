using System;
using UnityEngine;

namespace GameCamera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;

        private IMoveCamera _moveCameraController;

        private void Awake()
        {
            _moveCameraController = GetComponent<IMoveCamera>();
        }

        private void Start()
        {
            _moveCameraController?.SetTarget(targetTransform);
        }
    }
}