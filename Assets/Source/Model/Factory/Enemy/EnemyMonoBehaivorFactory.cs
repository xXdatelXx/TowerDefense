using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyMonoBehaivorFactory : MonoBehaviour
{
    [SerializeField] private EnemyPresenter _enemy;
    [SerializeField, Range(0, 10)] private float _speed;
    [SerializeField, Range(0, 100)] private int _health;
    [SerializeField, Range(0, 1)] private float _randomizedTarget;
    [SerializeField] private Transform _parent;
    private EnemyFactory _enemyFactory;

    [Inject]
    private void Construct(EnemyCounter enemyCounter)
    {
        _enemyFactory = new EnemyFactory(enemyCounter);
    }

    public EnemyPresenter Create(Vector2 position, List<Vector2> targets)
    {
        for (int i = 1; i < targets.Count; i++)
            targets[i] = targets[i].Randomize(_randomizedTarget);

        var movementFactory = new TargetMovementFactory(position, 0, targets, _speed);
        var movement = movementFactory.Create();

        var enemy = Instantiate(_enemy, position, Quaternion.identity, parent: _parent);
        enemy.Present(_enemyFactory.Create(movement, _health));

        return enemy;
    }
}
