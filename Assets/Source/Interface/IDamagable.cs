using System;

public interface IDamagable
{
    event Action OnDie;
    event Action<int> OnDamage;
}
