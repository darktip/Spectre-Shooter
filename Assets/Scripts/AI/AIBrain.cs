using System;
using System.Linq;
using Gameplay;
using Movement;
using UnityEngine;

namespace AI
{
    public class AIBrain : MonoBehaviour
    {
        protected IMove _moveController;
        protected IRotate _rotateController;

        protected Transform _playerTransform;

        protected virtual void Awake()
        {
            _moveController = GetComponent<IMove>();
            _rotateController = GetComponent<IRotate>();
        }

        protected virtual void OnEnable()
        {
            _playerTransform = PlayerInfo.Instance.PlayerTransform;
        }

        protected virtual void Update()
        {
            Tick();
        }

        protected virtual void Tick()
        {
            if (Vector3.SqrMagnitude(_playerTransform.position - transform.position) > 1)
            {
                Vector3 moveVector = (_playerTransform.position - transform.position).normalized;

                _moveController?.SetMoveVector(moveVector);
                _rotateController?.SetRotationVector(new Vector3(0,
                    Vector3.SignedAngle(transform.forward, moveVector,
                        Vector3.up), 0));
            }
            else
            {
                _moveController?.SetMoveVector(Vector3.zero);
                _rotateController?.SetRotationVector(Vector3.zero);
            }
        }
    }
}