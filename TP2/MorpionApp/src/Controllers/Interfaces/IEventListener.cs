using MorpionApp.Controllers.Enums;

namespace MorpionApp.Controllers.Interfaces;

public interface IEventListener
{
    void OnUpdate(EventTypes eventType, string message);
}