using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class TowerAffectButtonController : MonoBehaviour
{
    [SerializeField] private TowerPresenter _presenter;
    [Inject] private TowersButtons _buttons;

    private void OnMouseUp()
    {
        _buttons.AffectTower(_presenter);
    }
}
