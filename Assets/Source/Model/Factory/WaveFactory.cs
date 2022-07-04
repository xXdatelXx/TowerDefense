using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class WaveFactory : MonoBehaviour
{
    [SerializeField] private List<int> _enemys;
    [SerializeField] private List<Road> _roads;
    [SerializeField] private EnemyMonoBehaivorFactory _factory;
    [SerializeField, Range(0, 10)] private int _timeToSpawn;
    [SerializeField, Range(0, 10)] private int _timeToWave;
    private int _waveId;
    public event Action<int> OnSetWave;
    public int WavesCount => _enemys.Count;
    public bool End { get; private set; }

    private void OnValidate()
    {
        for (int i = 0; i < _enemys.Count; i++)
            _enemys[i] = _enemys[i] < 1 ? 1 : _enemys[i];
    }

    public IEnumerator StartWave()
    {
        if (_waveId == WavesCount)
            yield break;

        yield return new WaitForSeconds(_timeToWave);
        StartCoroutine(Spawn());

        OnSetWave?.Invoke(_waveId);
        _waveId++;

        if (_waveId == WavesCount)
            End = true;
    }

    private IEnumerator Spawn()
    {
        int wave = _waveId;
        var targets = _roads[Random.Range(0, _roads.Count)].Targets;

        for (int i = 0; i < _enemys[wave]; i++)
        {
            _factory.Create(targets[0].position, targets.Convert());
            yield return new WaitForSeconds(_timeToSpawn);
        }
    }

    [Serializable]
    public struct Road
    {
        [field: SerializeField] public List<Transform> Targets;
    }
}
