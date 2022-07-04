using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class HealthView : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void View(float health)
    {
        _text.text = "Health:" + health;
    }
}
