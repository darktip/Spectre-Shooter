using System;
using UnityEngine;

namespace GameInput
{
    public abstract class GameInputBase : ScriptableObject
    {
        public abstract bool WeaponChangeNext();
        public abstract bool WeaponChangePrevious();
        public abstract bool Shoot();
        public abstract bool SteerLeft();
        public abstract bool SteerRight();
        public abstract bool MoveForward();
        public abstract bool MoveBackwards();
    }
}
