using System;
using System.Collections.Generic;

public class EventList<T> : List<T>
{
    public event Action OnAdd;
    public event Action OnRemove;

    public new void Add(T item)
    {
        base.Add(item);
        OnAdd?.Invoke();
    }

    public new bool Remove(T item)
    {
        bool result = base.Remove(item);
        if (result)
        {
            OnRemove?.Invoke();
        }
        return result;
    }
}
