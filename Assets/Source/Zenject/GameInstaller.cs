using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private TowersButtons _towersButtons;
    [SerializeField] private TimerFactory _timerFactory;
    [SerializeField] private WalletPresenter _wallet;

    public override void InstallBindings()
    {
        Container.BindInstance(new EnemyCounter());
        Container.BindInstance(_towersButtons);
        Container.BindInstance(_timerFactory);
        Container.BindInstances(_wallet);
    }
}
