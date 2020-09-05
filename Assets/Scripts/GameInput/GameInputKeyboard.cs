using UnityEngine;

namespace GameInput
{
    [CreateAssetMenu(fileName = "New Keyboard Input", menuName = "Input/KeyboardInput", order = 50)]
    public class GameInputKeyboard : GameInputBase
    {
        [SerializeField] private KeyCode weaponChangeNextKey;
        [SerializeField] private KeyCode weaponChangePreviousKey;
        [SerializeField] private KeyCode shootKey;
        [SerializeField] private KeyCode steerLeftKey;
        [SerializeField] private KeyCode steerRightKey;
        [SerializeField] private KeyCode moveForwardKey;
        [SerializeField] private KeyCode moveBackwardsKey;
        
        public override bool WeaponChangeNext()
        {
            return Input.GetKeyDown(weaponChangeNextKey);
        }

        public override bool WeaponChangePrevious()
        {
            return Input.GetKeyDown(weaponChangePreviousKey);
        }

        public override bool Shoot()
        {
            return Input.GetKey(shootKey);
        }

        public override bool SteerLeft()
        {
            return Input.GetKey(steerLeftKey);
        }

        public override bool SteerRight()
        {
            return Input.GetKey(steerRightKey);
        }

        public override bool MoveForward()
        {
            return Input.GetKey(moveForwardKey);
        }

        public override bool MoveBackwards()
        {
            return Input.GetKey(moveBackwardsKey);
        }
    }
}