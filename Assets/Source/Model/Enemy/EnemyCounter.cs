using System;
using System.Collections.Generic;

public class EnemyCounter
{
    private List<Enemy> _enemies = new();
    public event Action OnZeroCount;

    public void Add(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void Remove(Enemy enemy)
    {
        _enemies.Remove(enemy);
        if (_enemies.Count == 0)
            OnZeroCount?.Invoke();
    }
}
