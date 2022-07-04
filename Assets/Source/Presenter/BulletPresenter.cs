using UnityEngine;

public class BulletPresenter : MonoBehaviour
{
    [SerializeField] private TransformableView _view;
    private Bullet _bullet;
    private EnemyPresenter _target;
    public int Damage => _bullet.Damage;

    public void Present(Bullet bullet, EnemyPresenter target)
    {
        _bullet = bullet;
        _target = target;
        _view.Init(bullet);
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        _bullet.SetTarget(_target.transform.position);
        _bullet.Move(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<EnemyPresenter>() != null)
            Destroy(gameObject);
    }
}
