namespace MorpionApp.Controllers.Interfaces;

public interface IGameSaveManager
{
    public void Save(GameController gameController);
    public GameController LoadSave();
    public void DeleteSave();
}