using System;
using UnityEngine;

namespace GameInput
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        public Vector2 Direction { get; private set; }
        public bool IsShoot { get; private set; }

        private void Update()
        {
            MoveDirection();
            Shoot();
        }

        private void MoveDirection()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Vector2 moveDirection = Vector2.zero;

            if (Mathf.Abs(horizontalInput) >= Mathf.Abs(verticalInput))
            {
                moveDirection.x = horizontalInput;
            }
            else
            {
                moveDirection.y = verticalInput;
            }

            Direction = moveDirection;
        }

        private void Shoot()
        {
            IsShoot = Input.GetKey(KeyCode.Space);
        }
    }
}