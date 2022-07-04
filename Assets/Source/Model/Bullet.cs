using System.Collections.Generic;
using UnityEngine;

public class Bullet : TargetMovement
{
    public int Damage { get; private set; }

    public Bullet(Vector2 position, float rotation, List<Vector2> targets, float speed, int damage) : base(position, rotation, targets, speed)
    {
        Damage = damage;
    }
}
