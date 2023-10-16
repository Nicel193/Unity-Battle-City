using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerTankConfig", menuName = "Game/PlayerTankConfig")]

    public class PlayerTankConfig : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; } = 1f;
        [field: SerializeField] public float ShootCooldown { get; private set; } = 0.5f;
    }
}