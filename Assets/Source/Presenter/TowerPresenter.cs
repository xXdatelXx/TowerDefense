using UnityEngine;

public class TowerPresenter : MonoBehaviour
{
    [SerializeField] private TowerView _view;
    [SerializeField] private TowerFactory _factory;
    [SerializeField] private TowerCharacteristics _updateCharacteristics;
    private Tower _tower;
    private int _towerVersion;
    public bool CanUpdate => _towerVersion + 1 < _updateCharacteristics.UpdateCount;
    public TowerCharacteristic Characteristic => _updateCharacteristics[_towerVersion];

    private void Start()
    {
        _tower = _factory.Create(_updateCharacteristics[_towerVersion]);
    }

    public void UpdateTower()
    {
        if (CanUpdate)
        {
            _towerVersion++;
            _tower.UpdateCharacteristic(_updateCharacteristics[_towerVersion]);
            _view.SetSprite(_updateCharacteristics[_towerVersion].Sprite);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        _tower.Shoot();
    }
}
