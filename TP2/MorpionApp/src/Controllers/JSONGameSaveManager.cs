using System.Text.Json;
using MorpionApp.Controllers.Interfaces;

namespace MorpionApp.Controllers;

public class JSONGameSaveManager : IGameSaveManager
{
    private string saveFilePath;
    
    public JSONGameSaveManager(string saveFilePath)
    {
        this.saveFilePath = saveFilePath;
    }
    
    public void Save(GameController gameController)
    {
        string jsonString = JsonSerializer.Serialize(gameController);
        
        System.IO.File.WriteAllText(saveFilePath, jsonString);
    }

    public GameController LoadSave()
    {
        string jsonString = System.IO.File.ReadAllText(saveFilePath);

        return JsonSerializer.Deserialize<GameController>(jsonString);
    }
    
    public void DeleteSave()
    {
        System.IO.File.Delete(saveFilePath);
    }
}