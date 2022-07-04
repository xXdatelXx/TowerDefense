using UnityEngine;

public class EndGameView : MonoBehaviour
{
    [SerializeField] private LoseEcran _loseEcran;
    [SerializeField] private WinEcran _winEcran;
    private bool _endGame;

    public void Finish()
    {
        ActivateEcran(_winEcran.gameObject);
    }

    public void Lose()
    {
        ActivateEcran(_loseEcran.gameObject);
    }

    private void ActivateEcran(GameObject ecran)
    {
        if (_endGame)
            return;

        ecran.SetActive(true);
        _endGame = true;
    }
}
