using System;
using System.Collections.Generic;

public static class EventManager<T> where T : EventArgs
{
    public static Dictionary<string, EventHandler<T>> events = new Dictionary<string, EventHandler<T>>();

    public static void Add(string key, EventHandler<T> other) {
        if (events.ContainsKey(key))
        {
            events[key] += other;
        }
        else
        {
            events.Add(key, other);
        }
    }

    public static void Remove(string key, EventHandler<T> other)
    {
        if (events.ContainsKey(key))
        {
            events[key] -= other;
        }
    }

    public static void Invoke(object sender, string key)
    {
        if (events.ContainsKey(key))
        {
            events[key]?.Invoke(sender, null);
        }
    }

    public static void Invoke(object sender, string key, T args)
    {
        if (events.ContainsKey(key))
        {
            events[key]?.Invoke(sender, args);
        }
    }
}
