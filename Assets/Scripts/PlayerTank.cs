using Configs;
using GameInput;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerTank : MonoBehaviour
    {
        [SerializeField] private DefaultBullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPosition;
        [SerializeField] private PlayerTankConfig _playerTankConfig;
        [SerializeField] private PlayerInput _playerInput;

        private TankMovement _tankMovement;
        private IBulletFactory _bulletFactory;
        public float shootCooldown = 0.5f;
        private float lastShootTime;

        private void Start()
        {
            _tankMovement = new TankMovement(GetComponent<Rigidbody2D>());
            _bulletFactory = new BulletFactory(_bulletPrefab, this.transform, _bulletSpawnPosition);
        }

        private void Update()
        {
            if (_playerInput.IsShoot && Time.time - lastShootTime >= shootCooldown)
            {
                _bulletFactory.CreateBullet();
                lastShootTime = Time.time;
            }
        }

        private void FixedUpdate() => _tankMovement.Move(_playerInput.Direction, _playerTankConfig.Speed);
    }
}