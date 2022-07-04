using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

[RequireComponent(typeof(Button))]
public abstract class TowerButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _costText;
    private WalletPresenter _wallet;
    private int _cost;
    private Button _button;

    [Inject]
    private void Construct(WalletPresenter wallet)
    {
        _wallet = wallet;
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        _button.onClick.AddListener(() => Buy(_wallet));
    }

    private void OnEnable()
    {
        SetCost();
        _button.interactable = CanBuy(_wallet) && Active();
    }

    private void SetCost()
    {
        _cost = GetCost();
        _costText.text = _cost.ToString();
    }

    protected virtual void Buy(WalletPresenter wallet)
    {
        wallet.Buy(_cost);
    }

    protected virtual bool CanBuy(WalletPresenter wallet)
    {
        return _wallet.CanBuy(_cost);
    }

    protected virtual bool Active()
    {
        return true;
    }

    protected abstract void OnClick();
    protected abstract int GetCost();
}
