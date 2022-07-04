public class UpdateButton : TowerButton
{
    private TowerPresenter _presenter;

    public void SetPresenter(TowerPresenter presenter)
    {
        _presenter = presenter;
    }

    protected override void OnClick()
    {
        _presenter.UpdateTower();
    }

    protected override int GetCost()
    {
        return _presenter.Characteristic.Cost;
    }

    protected override bool Active()
    {
        return _presenter.CanUpdate;
    }
}
