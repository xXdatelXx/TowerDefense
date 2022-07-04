using System;

public class Tower
{
    public event Action OnShoot;
    private TowerCharacteristic _characteristic;
    private Finder _enemyFinder;
    private BulletsFactory _bulletsFactory;
    private Timer _timer;
    private bool _reloading;

    public Tower(TowerCharacteristic characteristic, Finder finder, BulletsFactory bulletsFactory, Timer timer)
    {
        UpdateCharacteristic(characteristic);
        _enemyFinder = finder;
        _bulletsFactory = bulletsFactory;
        _timer = timer;
        _timer.AddAction(() => _reloading = false);
        Reload();
    }

    public void UpdateCharacteristic(TowerCharacteristic characteristic)
    {
        _characteristic = characteristic;
    }

    public void Shoot()
    {
        if (_reloading)
            return;

        var enemy = _enemyFinder.FindNearest<EnemyPresenter>(_characteristic.AttackRadius);

        if (enemy != null)
        {
            OnShoot?.Invoke();
            _bulletsFactory.Create(enemy, _characteristic.Damage);
            Reload();
        }
    }

    private void Reload()
    {
        _reloading = true;
        _timer.Reset();
    }
}
