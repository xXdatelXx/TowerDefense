using UnityEngine;
using Zenject;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private Finder _enemyFinder;
    [SerializeField] private BulletsFactory _bulletsFactory;
    private TimerFactory _timerFactory;

    [Inject]
    private void Construct(TimerFactory timerFactory)
    {
        _timerFactory = timerFactory;
    }

    public Tower Create(TowerCharacteristic characteristic)
    {
        return new Tower(characteristic, _enemyFinder, _bulletsFactory, _timerFactory.Create(characteristic.Reload));
    }
}
