using System;

public class EnemyFactory
{
    private EnemyCounter _enemyCounter;

    public EnemyFactory(EnemyCounter enemyCounter)
    {
        _enemyCounter = enemyCounter;
    }

    public Enemy Create(Movement movement, int health)
    {
        if (health < 0)
            throw new ArgumentOutOfRangeException(health.ToString());

        var enemy = new Enemy(health, movement);
        _enemyCounter.Add(enemy);

        return enemy;
    }
}
