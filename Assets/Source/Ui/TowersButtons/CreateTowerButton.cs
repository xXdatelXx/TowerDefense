using UnityEngine;

public class CreateTowerButton : TowerButton
{
    [SerializeField] private TowerPresenter _tower;
    private TowerMonoBehaivorFactory _factory;

    public void SetFactory(TowerMonoBehaivorFactory factory)
    {
        _factory = factory;
    }

    protected override void OnClick()
    {
        _factory.Create(_tower);
    }

    protected override int GetCost()
    {
        return _tower.Characteristic.Cost;
    }

    protected override bool Active()
    {
        return _factory == null ? true : _factory.CanSpawn;
    }
}
