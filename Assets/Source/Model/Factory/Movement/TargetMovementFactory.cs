using System.Collections.Generic;
using UnityEngine;

public class TargetMovementFactory : MovementFactory
{
    private readonly Vector2 _position;
    private readonly float _rotation;
    private readonly List<Vector2> _targets;
    private readonly float _speed;

    public TargetMovementFactory(Vector2 position, float rotation, List<Vector2> targets, float speed)
    {
        _position = position;
        _rotation = rotation;
        _targets = targets;
        _speed = speed;
    }

    public override Movement Create()
    {
        return new TargetMovement(_position, _rotation, _targets, _speed);
    }
}
