using System.Collections.Generic;
using UnityEngine;

public class BulletsFactory : MonoBehaviour
{
    [SerializeField] private BulletPresenter _bulletPresenter;
    [SerializeField, Range(0, 10)] private int _bulletSpeed;

    public void Create(EnemyPresenter target, int damage)
    {
        var targets = new List<Vector2>();
        targets.Add(target.transform.position);

        var bullet = new Bullet(transform.position, 0, targets, _bulletSpeed, damage);
        var presenter = Instantiate(_bulletPresenter);

        presenter.Present(bullet, target);
    }
}
