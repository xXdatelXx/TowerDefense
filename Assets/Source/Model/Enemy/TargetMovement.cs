using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : Movement
{
    private readonly List<Vector2> _targets;
    private readonly float _speed;
    private int _targetId;

    public TargetMovement(Vector2 position, float rotation, List<Vector2> targets, float speed) : base(position, rotation)
    {
        _targets = targets;
        _speed = speed;
    }

    public void SetTarget(Vector2 target)
    {
        _targets[_targetId] = target;
    }

    public override void Move(float deltaTime)
    {
        if (_targetId == _targets.Count)
            return;

        Vector2 target = _targets[_targetId];
        Position = Vector2.MoveTowards(Position, target, _speed * deltaTime);

        if (Position == target)
            _targetId++;
    }
}
