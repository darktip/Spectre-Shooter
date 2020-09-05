using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public interface IRotate
    {
        void SetRotationVector(Vector3 eulerRotation);
    }
}