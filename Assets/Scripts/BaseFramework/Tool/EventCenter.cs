using System.Collections.Generic;
using UnityEngine.Events;

public interface IEvent
{

}
public class EventAction : IEvent
{
    public UnityAction eventAction;

    public EventAction( UnityAction action)
    {
        eventAction += action;
    }
    public void Trigger()
    {
        if (eventAction != null)
        {
            eventAction.Invoke();
        }
    }

}

public class EventAction<T> : IEvent
{
    public UnityAction<T> eventAction;

    public EventAction(UnityAction<T> action)
    {
        eventAction += action;
    }
    public void Trigger(T info)
    {
        if(eventAction!=null)
        {
            eventAction.Invoke(info);
        }
    }

}


public class EventCenter : BaseManager<EventCenter>
{
    
    public Dictionary<string, IEvent> dicEvent = new Dictionary<string, IEvent>();

    public void AddListener(string eventName,UnityAction action)
    {
          if(dicEvent.ContainsKey(eventName))
        {
            (dicEvent[eventName] as EventAction).eventAction += action;
        }
          else
        {
            dicEvent.Add(eventName, new EventAction(action));
        }
    }
    public void RemoveListener(string eventName, UnityAction action)
    {
        if (dicEvent.ContainsKey(eventName))
        {
            (dicEvent[eventName] as EventAction).eventAction -= action;
        }
       
    }
    public void EventTrigger(string eventName)
    {
        if(dicEvent.ContainsKey(eventName))
        {
            (dicEvent[eventName] as EventAction).Trigger();
        }
    }
    public void AddListener<T>(string eventName, UnityAction<T> action)
    {
        if (dicEvent.ContainsKey(eventName))
        {
            (dicEvent[eventName] as EventAction<T>).eventAction += action;
        }
        else
        {
            dicEvent.Add(eventName, new EventAction<T>(action));
        }
    }
    public void RemoveListener<T>(string eventName, UnityAction<T> action)
    {
        if (dicEvent.ContainsKey(eventName))
        {
            (dicEvent[eventName] as EventAction<T>).eventAction -= action;
        }

    }
    public void EventTrigger<T>(string eventName,T info)
    {
        if (dicEvent.ContainsKey(eventName))
        {
            (dicEvent[eventName] as EventAction<T>).Trigger(info);
        }
    }

    public void Clear()
    {
        dicEvent.Clear();
    }
}
