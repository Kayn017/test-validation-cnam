using MorpionApp.Controllers;

namespace MorpionApp.Views.Interfaces;

public interface IMenuView
{
    public MenuController MenuController { get; set; }
    
    public void Show();
    public void DisplayGameList();
    public void ChooseGame();
    public void DisplayPlayerTypeList();

    public void CreatePlayer();

}