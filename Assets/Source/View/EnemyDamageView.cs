using UnityEngine;
using Zenject;

public class EnemyDamageView : MonoBehaviour
{
    [Inject] private WalletPresenter _wallet;

    public void Die()
    {
        _wallet.Add();
        Destroy(gameObject);
    }

    public void Damage(int health)
    { }
}
