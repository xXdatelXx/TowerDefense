using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PausePresenter : MonoBehaviour
{
    [SerializeField] private PauseView _view;
    private Button _button;
    private Pause _pause;

    private void Awake()
    {
        _pause = new Pause();
        _pause.Stop();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Handled);
    }

    private void Handled()
    {
        if (!_pause.Value)
        {
            _pause.Play();
            _view.Pause();
        }
        else
        {
            _pause.Stop();
            _view.Play();
        }
    }
}
