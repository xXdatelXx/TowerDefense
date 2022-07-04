using UnityEngine;

public class TowerMonoBehaivorFactory : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Transform _parent;
    private TowerPresenter _tower;
    public bool CanSpawn => _tower == null;

    public void Create(TowerPresenter tower)
    {
        if (CanSpawn)
            _tower = Instantiate(tower, _spawnPosition.position, Quaternion.identity, parent: _parent);
    }
}
