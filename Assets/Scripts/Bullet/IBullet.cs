using UnityEngine;

namespace Scripts
{
    public interface IBullet
    {
        void SetMovement(Vector3 directionFlight, GameObject shooter);
    }
}