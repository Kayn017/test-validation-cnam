using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Interfaces;

namespace MorpionApp.Controllers;

public class EventManager
{
    private Dictionary<EventTypes, List<IEventListener>> Listeners = new();
    
    public EventManager() {}
    
    public void addListener(EventTypes eventType, IEventListener listener)
    {
        if (!Listeners.ContainsKey(eventType))
        {
            Listeners[eventType] = new List<IEventListener>();
        }
        Listeners[eventType].Add(listener);
    }
    
    public void removeListener(EventTypes eventType, IEventListener listener)
    {
        if (Listeners.ContainsKey(eventType))
        {
            Listeners[eventType].Remove(listener);
        }
    }
    
    public void notify(EventTypes eventType, string message = "")
    {
        if (Listeners.ContainsKey(eventType))
        {
            foreach (IEventListener listener in Listeners[eventType])
            {
                listener.OnUpdate(eventType, message);
            }
        }
    }
}