using System;
using System.Collections.Generic;

public class EventListernerEnum
{
    public const string EVENT_CHANGE_STATE = "ChangeGameState";
}

public class EventListenerManager
{
    private static EventListenerManager _instance = null;
    public static EventListenerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventListenerManager();
            }
            return _instance;
        }
    }

    private Dictionary<string, Action<object>> eventActions = new Dictionary<string, Action<object>>();

    public void Subscribe(string name, Action<object> action)
    {
        if (eventActions.ContainsKey(name))
        {
            Action<object> evs = eventActions[name];
            evs += action;
            eventActions[name] = evs;
        }
        else
        {
            eventActions.Add(name, action);
        }
    }

    public void UnSubscribe(string name, Action<object> action = null)
    {
        if (eventActions.ContainsKey(name))
        {
            if (action != null)
            {
                eventActions[name] -= action;
            }

            if (action == null || eventActions[name] == null)
            {
                eventActions.Remove(name);
            }
        }
    }

    public void Fire(string name, object o = null)
    {
        if (eventActions.ContainsKey(name))
        {
            Action<object> evs = eventActions[name];
            evs.Invoke(o);
        }
    }
}
