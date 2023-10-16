using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DefaultBullet : MonoBehaviour, IBullet
    {
        public float bulletSpeed = 10.0f;
        private Rigidbody2D rb;
        private GameObject _shooter;
        
        public void SetMovement(Vector3 directionFlight, GameObject shooter)
        {
            rb = this.GetComponent<Rigidbody2D>();
            _shooter = shooter;
            
            rb.velocity = directionFlight * bulletSpeed;    
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.collider.gameObject == gameObject) return;
            
            Destroy(this.gameObject);
        }
    }
}