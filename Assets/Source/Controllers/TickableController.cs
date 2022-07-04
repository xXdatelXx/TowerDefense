using System;
using System.Collections.Generic;
using UnityEngine;

public class TickableController : MonoBehaviour
{
    private readonly List<ITickable> _tickables = new List<ITickable>();

    private void Update()
    {
        _tickables.ForEach(tickable => tickable.Tick(Time.deltaTime));
    }

    public void Add(ITickable tickable)
    {
        if (tickable is null)
            throw new ArgumentNullException(nameof(tickable));

        _tickables.Add(tickable);
    }

    public void Remove(ITickable tickable)
    {
        _tickables.Remove(tickable);
    }
}
