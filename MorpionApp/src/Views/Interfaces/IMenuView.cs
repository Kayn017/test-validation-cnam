using MorpionApp.Controllers;

namespace MorpionApp.Views.Interfaces;

public interface IMenuView
{
    public MenuController MenuController { get; set; }
    
    public void Show();
}