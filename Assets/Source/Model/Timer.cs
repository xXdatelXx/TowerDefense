using System;

public class Timer : ITickable
{
    private event Action _onEnd;
    private readonly float _time;
    private float _accumulatedTime;

    private bool _finish => _accumulatedTime >= _time;

    public Timer(float time)
    {
        if (time < 0)
            throw new ArgumentOutOfRangeException();

        _time = time;
    }

    public void AddAction(Action action)
    {
        _onEnd += action;
    }

    public void Tick(float deltaTime)
    {
        if (deltaTime < 0)
            throw new ArgumentOutOfRangeException();

        if (_finish)
            return;

        _accumulatedTime += deltaTime;

        if (_finish)
            _onEnd?.Invoke();
    }

    public void Reset()
    {
        _accumulatedTime = 0;
    }
}
