using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HealthPresenter : MonoBehaviour
{
    [SerializeField] private HealthView _healthView;
    [SerializeField] private EndGameView _loseView;
    [SerializeField, Range(0, 100)] private int _healthPoint;
    private Damagable _health;

    private void Awake()
    {
        _health = new Damagable(_healthPoint);
    }

    private void OnEnable()
    {
        _health.OnDie += _loseView.Lose;
    }

    private void OnDisable()
    {
        _health.OnDie -= _loseView.Lose;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyPresenter>() != null)
        {
            _health.Damage(1);
            _healthView.View(_health.Health);
        }
    }
}
