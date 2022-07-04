using UnityEngine;

public class WalletPresenter : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int _startCoins;
    [SerializeField] private WalletView _view;
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet(_startCoins);
        _view.View(_wallet.Coins);
    }

    private void OnEnable()
    {
        _wallet.OnSetCoins += _view.View;
    }

    private void OnDisable()
    {
        _wallet.OnSetCoins -= _view.View;
    }

    public bool CanBuy(int coins)
    {
        return _wallet.CanBuy(coins);
    }

    public void Buy(int coins)
    {
        _wallet.Buy(coins);
    }

    public void Add()
    {
        _wallet.Add();
    }

    public void Add(int coins)
    {
        _wallet.Add(coins);
    }
}
