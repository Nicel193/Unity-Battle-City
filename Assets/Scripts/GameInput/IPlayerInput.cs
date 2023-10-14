using System;
using UnityEngine;

namespace GameInput
{
    public interface IPlayerInput
    {
        Vector2 Direction { get; }
        bool IsShoot { get; }
    }
}