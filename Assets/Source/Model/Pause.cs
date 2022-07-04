using System.Collections.Generic;
using UnityEngine;
using System;

public class Pause
{
    private readonly List<IPauseHandler> _handlers = new();
    public bool Value { get; private set; }

    public void AddPauseHandler(IPauseHandler handler)
    {
        if (handler == null)
            throw new ArgumentNullException(handler.ToString());

        _handlers.Add(handler);
    }

    public void Play()
    {
        Time.timeScale = 0;
        Value = true;
        foreach (var handler in _handlers)
            handler.Pause();
    }

    public void Stop()
    {
        Time.timeScale = 1;
        Value = false;
        foreach (var handler in _handlers)
            handler.Resume();
    }

    private void SetState(int timeScale, List<Action> handlers)
    {
        Time.timeScale = timeScale;
        Value = !Value;
        foreach (var handler in handlers)
            handler.Invoke();
    }
}
