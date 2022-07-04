using System;

public class Damagable
{
    public event Action OnDie;
    public event Action<int> OnDamage;
    public int Health { get; private set; }

    public Damagable(int health)
    {
        if (health <= 0)
            throw new ArgumentOutOfRangeException(health.ToString() + "<= 0");

        Health = health;
    }

    public void Damage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(damage.ToString() + "< 0");

        if (Health == 0)
            return;

        Health -= damage;
        OnDamage?.Invoke(Health);

        if (Health <= 0)
        {
            Health = 0;
            OnDie?.Invoke();
        }
    }
}
