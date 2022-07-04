using UnityEngine;
using Zenject;

public class WavePresenter : MonoBehaviour
{
    [SerializeField] private WaveFactory _factory;
    [SerializeField] private WaveView _waveView;
    [SerializeField] private EndGameView _endGameView;
    private EnemyCounter _enemyCounter;

    [Inject]
    private void Construct(EnemyCounter enemyCounter)
    {
        _enemyCounter = enemyCounter;
    }

    private void Start()
    {
        StartWave();
        _waveView.SetWavesCount(_factory.WavesCount);
    }

    private void OnEnable()
    {
        _factory.OnSetWave += _waveView.View;
        _enemyCounter.OnZeroCount += StartWave;
        _enemyCounter.OnZeroCount += CheckEndGame;
    }

    private void OnDisable()
    {
        _factory.OnSetWave -= _waveView.View;
        _enemyCounter.OnZeroCount -= StartWave;
        _enemyCounter.OnZeroCount -= CheckEndGame;
    }

    private void CheckEndGame()
    {
        if (_factory.End)
            _endGameView.Finish();
    }

    private void StartWave()
    {
        StartCoroutine(_factory.StartWave());
    }
}
