public class DestroyButton : TowerButton
{
    private TowerPresenter _presenter;

    public void SetPresenter(TowerPresenter presenter)
    {
        _presenter = presenter;
    }

    protected override void OnClick()
    {
        _presenter.Destroy();
    }

    protected override int GetCost()
    {
        return _presenter.Characteristic.Cost;
    }

    protected override void Buy(WalletPresenter wallet)
    {
        wallet.Add(GetCost());
    }

    protected override bool CanBuy(WalletPresenter wallet)
    {
        return true;
    }
}
