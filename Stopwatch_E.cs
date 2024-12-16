using System;
using System.Threading;

public class Stopwatch_E
{
    // Fields
    private TimeSpan timeElapsed;
    private bool isRunning;
    private Timer timer;

    // Delegate and events
    public delegate void StopwatchEventHandler(string message);
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    // Start method
    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            timer = new Timer(Tick, null, 0, 1000);
            OnStarted?.Invoke("Stopwatch Started!");
        }
    }

    // Stop method
    public void Stop()
    {
        if (isRunning)
        {
            isRunning = false;
            timer?.Dispose();
            OnStopped?.Invoke("Stopwatch Stopped!");
        }
    }

    // Reset method
    public void Reset()
    {
        isRunning = false;
        timer?.Dispose();
        timeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
    }

    // Tick method
    private void Tick(object state)
    {
        timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
        Console.WriteLine($"Time Elapsed: {timeElapsed}");
    }
}
