using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] private TransformableView _transformableView;
    [SerializeField] private EnemyDamageView _damageView;
    private Enemy _enemy;
    private EnemyCounter _enemyCounter;

    [Inject]
    private void Construct(EnemyCounter enemyCounter)
    {
        _enemyCounter = enemyCounter;
    }

    public void Present(Enemy enemy)
    {
        _enemy = enemy;
        _enemy.AddDieHandler(Die);
        _enemy.AddDieHandler(_damageView.Die);
        _enemy.AddDamageHandler(_damageView.Damage);
        _transformableView.Init(_enemy.Transformable);
    }

    private void OnDisable()
    {
        if (_enemy == null)
            return;

        _enemy.RemoveDieHandler(_damageView.Die);
        _enemy.RemoveDamageHandler(_damageView.Damage);
    }

    private void Update()
    {
        if (_enemy == null)
            return;

        _enemy.Move(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<BulletPresenter>(out BulletPresenter bullet))
            _enemy.Damage(bullet.Damage);
        if (collision.gameObject.GetComponent<HealthPresenter>() != null)
            Die();
    }

    private void Die()
    {
        _enemyCounter.Remove(_enemy);
        Destroy(gameObject);
    }
}
