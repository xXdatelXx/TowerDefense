using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowersButtons : MonoBehaviour
{
    [SerializeField] private List<CreateTowerButton> _towers;
    [SerializeField] private UpdateButton _update;
    [SerializeField] private DestroyButton _destroy;
    private List<Button> _allButtons = new();
    private int _touches;

    private void Awake()
    {
        DisabledButtons();

        foreach (var tower in _towers)
            _allButtons.Add(tower.GetComponent<Button>());
        _allButtons.Add(_update.GetComponent<Button>());
        _allButtons.Add(_destroy.GetComponent<Button>());

        foreach (var button in _allButtons)
            button.onClick.AddListener(DisabledButtons);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _touches++;
            // 1 - включили, 2 - десь нажали
            if (_touches == 2)
            {
                _touches = 0;
                DisabledButtons();
            }
        }
    }

    public void CreateTower(TowerMonoBehaivorFactory factory)
    {
        DisabledButtons();

        foreach (var tower in _towers)
        {
            tower.gameObject.SetActive(true);
            tower.SetFactory(factory);
        }

        transform.position = factory.transform.position;
    }

    public void AffectTower(TowerPresenter presenter)
    {
        DisabledButtons();

        _update.SetPresenter(presenter);
        _update.gameObject.SetActive(true);
        _destroy.SetPresenter(presenter);
        _destroy.gameObject.SetActive(true);

        transform.position = presenter.transform.position;
    }

    private void DisabledButtons()
    {
        _update.gameObject.SetActive(false);
        _destroy.gameObject.SetActive(false);
        foreach (var tower in _towers)
            tower.gameObject.SetActive(false);
    }
}
