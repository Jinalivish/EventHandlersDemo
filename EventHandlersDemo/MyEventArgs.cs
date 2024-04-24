using System;

public class MyEventArgs : EventArgs
{
    public string Message { get; }

    public MyEventArgs(string message)
    {
        Message = message;
    }
}


public delegate void MyEventHandler(object sender, MyEventArgs e);

public class EventPublisher
{
    public event MyEventHandler MyEvent;

    public void RaiseEvent(string message)
    {
        OnMyEvent(new MyEventArgs(message));
    }

    protected virtual void OnMyEvent(MyEventArgs e)
    {
        MyEvent?.Invoke(this, e);
    }
}

public class EventHandler
{
    public void HandleEvent(object sender, MyEventArgs e)
    {
        Console.WriteLine($"Event handled: {e.Message}");
    }
}
