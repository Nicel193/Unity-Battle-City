using GameInput;
using UnityEngine;

namespace Scripts
{
    public class TankShooter
    {
        private IPlayerInput _playerInput;
        private IBulletFactory _bulletFactory;
        private float _shootCooldown;
        private float _lastShootTime;
     
        public TankShooter(IPlayerInput playerInput, IBulletFactory bulletFactory, float shootCooldown)
        {
            _playerInput = playerInput;
            _bulletFactory = bulletFactory;
            _shootCooldown = shootCooldown;
        }
        
        public void ShootUpdate()
        {
            if (_playerInput.IsShoot && Time.time - _lastShootTime >= _shootCooldown)
            {
                _bulletFactory.CreateBullet();
                _lastShootTime = Time.time;
            }
        }
    }
}