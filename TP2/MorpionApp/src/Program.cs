

using MorpionApp.Controllers;
using MorpionApp.Views.Console;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuController menuController = new MenuController();
            ConsoleMenuView menu = new ConsoleMenuView(menuController);

            menu.Show();            
        }
    }
}
