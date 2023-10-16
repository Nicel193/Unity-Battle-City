using UnityEngine;

namespace Scripts
{
    public class BulletFactory : IBulletFactory
    {
        private DefaultBullet _bulletPrefab;
        private Transform _tank;
        private Transform _bulletSpawnPosition;

        public BulletFactory(DefaultBullet bulletPrefab, Transform tank, Transform bulletSpawnPosition)
        {
            _bulletPrefab = bulletPrefab;
            _tank = tank;
            _bulletSpawnPosition = bulletSpawnPosition;
        }

        public void CreateBullet()
        {
            Vector3 directionToPlayer = (_tank.position - _bulletSpawnPosition.position).normalized;
            DefaultBullet bullet =
                Object.Instantiate(_bulletPrefab, _bulletSpawnPosition.position,
                    Quaternion.Euler(0, 0,
                        Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg + 90));
            
            bullet.SetMovement(-directionToPlayer, _tank.gameObject);
        }
    }
}