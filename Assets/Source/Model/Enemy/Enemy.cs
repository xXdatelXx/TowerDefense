using System;

public class Enemy
{
    private readonly Movement _movement;
    private readonly Damagable _health;
    public Transformable Transformable => _movement;

    public Enemy(int health, Movement movement)
    {
        _health = new Damagable(health);
        _movement = movement;
    }

    public void Move(float deltaTime)
    {
        _movement.Move(deltaTime);
    }

    public void Damage(int damage)
    {
        _health.Damage(damage);
    }

    public void AddDieHandler(Action handler)
    {
        _health.OnDie += handler;
    }

    public void RemoveDieHandler(Action handler)
    {
        _health.OnDie -= handler;
    }

    public void AddDamageHandler(Action<int> handler)
    {
        _health.OnDamage += handler;
    }

    public void RemoveDamageHandler(Action<int> handler)
    {
        _health.OnDamage -= handler;
    }
}
