using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class TowerCreateButtonController : MonoBehaviour
{
    [SerializeField] private TowerMonoBehaivorFactory _factory;
    [Inject] private TowersButtons _buttons;

    private void OnMouseUp()
    {
        _buttons.CreateTower(_factory);
    }
}
