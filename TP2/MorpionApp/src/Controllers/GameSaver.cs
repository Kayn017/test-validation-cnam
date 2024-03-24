using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Interfaces;

namespace MorpionApp.Controllers;

public class GameSaver : IEventListener
{
    private IGameSaveManager gameSaveManager;
    private GameController gameController;
    
    public GameSaver(IGameSaveManager gameSaveManager, GameController gameController)
    {
        this.gameSaveManager = gameSaveManager;
        this.gameController = gameController;
    }

    public void OnUpdate(EventTypes eventType, string message)
    {
        if(eventType == EventTypes.Win)
        {
            gameSaveManager.DeleteSave();
        }
        else
        {
            gameSaveManager.Save(gameController);
        }
    }
}