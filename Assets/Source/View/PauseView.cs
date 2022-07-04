using UnityEngine;

public class PauseView : MonoBehaviour
{
    [SerializeField] private PauseEcran _pauseEcran;

    public void Pause()
    {
        _pauseEcran.gameObject.SetActive(true);
    }

    public void Play()
    {
        _pauseEcran.gameObject.SetActive(false);
    }
}
