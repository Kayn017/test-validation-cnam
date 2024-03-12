using MorpionApp.Controllers;
using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Interfaces;
using Xunit;

namespace MorpionAppTest.Controllers;


public class EventManagerTest
{
    public class ExampleListener : IEventListener
    {
        public void OnUpdate(EventTypes eventType, string message)
        {
            Assert.True(true);
        }
    }
    
    [Fact]
    public void AddListeners()
    {
        // Arrange
        EventManager em = new EventManager();

        // Act
        em.addListener(EventTypes.Play, new ExampleListener());
        
        // Assert
        em.notify(EventTypes.Play);
    }
}