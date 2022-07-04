using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class WalletView : MonoBehaviour
{
    private TMP_Text _text;

    public void View(int coins)
    {
        if (_text == null)
            _text = GetComponent<TMP_Text>();

        _text.text = "Coins:" + coins;
    }
}
