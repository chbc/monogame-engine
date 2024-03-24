using System;

public class Timer
{
    private Action _callback;
    private double _duration;
    private double _time;
    private bool _active = false;
    private bool _repeat;

    public void Start(Action callback, double duration, bool repeat)
    {
        _callback = callback;
        _duration = duration;
        _time = duration;
        _repeat = repeat;
        _active = true;
    }

    public void Update(double deltaTime)
    {
        if (!_active)
        {
            return;
        }

        _time = _time - deltaTime;

        if (_time < 0.0)
        {
            _callback.Invoke();

            if (_repeat)
            {
                _time = _duration;
            }
            else
            {
                _active = false;
            }
        }
    }
}
