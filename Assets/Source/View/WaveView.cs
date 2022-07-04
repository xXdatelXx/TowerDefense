using UnityEngine;
using System;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class WaveView : MonoBehaviour
{
    private TMP_Text _text;
    private int _wavesCont;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void SetWavesCount(int wavesCont)
    {
        if (wavesCont < 0)
            throw new ArgumentOutOfRangeException();

        _wavesCont = wavesCont;
    }

    public void View(int wave)
    {
        _text.text = "Wave:" + (wave + 1) + "/" + _wavesCont;
    }
}
