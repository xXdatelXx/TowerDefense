using UnityEngine;

public class TimerFactory : MonoBehaviour
{
    [SerializeField] private TickableController _tickableController;

    public Timer Create(float time)
    {
        var timer = new Timer(time);
        _tickableController.Add(timer);
        return timer;
    }
}
