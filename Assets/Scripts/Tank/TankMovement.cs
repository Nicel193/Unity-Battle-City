using UnityEngine;

namespace Scripts
{
    public class TankMovement
    {
        private Rigidbody2D _rigidbody2D;

        public TankMovement(Rigidbody2D rigidbody2D)
            => _rigidbody2D = rigidbody2D;
        
        public void Move(Vector2 direction, float speed)
        {
            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
                _rigidbody2D.MoveRotation(Quaternion.Euler(0, 0, angle));
            }

            _rigidbody2D.MovePosition(_rigidbody2D.position + direction *
                (speed * Time.fixedDeltaTime));
        }
    }
}