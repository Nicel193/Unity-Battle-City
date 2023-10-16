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
        private TankShooter _tankShooter;
        

        private void Start()
        {
            IBulletFactory bulletFactory = new BulletFactory(_bulletPrefab, this.transform, _bulletSpawnPosition);
            
            _tankMovement = new TankMovement(GetComponent<Rigidbody2D>());
            _tankShooter = new TankShooter(_playerInput, bulletFactory, _playerTankConfig.ShootCooldown);
        }

        private void Update() => _tankShooter.ShootUpdate();
        private void FixedUpdate() => _tankMovement.Move(_playerInput.Direction, _playerTankConfig.Speed);
    }
}