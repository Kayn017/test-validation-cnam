using MorpionApp;
using Xunit;

namespace MorpionAppTest;

public class MorpionTest
{
    [Fact]
    public void CheckHorizontalVictoire()
    {   
        Morpion morpion = new Morpion();
        
        morpion.grille = new char[3, 3]
        {
            { 'X', 'X', 'X'},
            { ' ', ' ', ' '},
            { ' ', ' ', ' '},
        };
        
        Assert.True(morpion.verifVictoire('X'));
    }

    [Fact]
    public void CheckVerticalVictoire()
    {
        Morpion morpion = new Morpion();
        
        morpion.grille = new char[3, 3]
        {
            { 'X', ' ', ' '},
            { 'X', ' ', ' '},
            { 'X', ' ', ' '},
        };
        
        Assert.True(morpion.verifVictoire('X'));
    }
    
    [Fact]
    public void CheckDiagonalVictoire()
    {
        Morpion morpion = new Morpion();
        
        morpion.grille = new char[3, 3]
        {
            { 'X', ' ', ' '},
            { ' ', 'X', ' '},
            { ' ', ' ', 'X'},
        };
        
        Assert.True(morpion.verifVictoire('X'));
    }
    
    [Fact]
    public void CheckPasVictoire()
    {
        Morpion morpion = new Morpion();
        
        morpion.grille = new char[3, 3]
        {
            { 'X', ' ', ' '},
            { ' ', ' ', ' '},
            { ' ', ' ', 'X'},
        };
        
        Assert.False(morpion.verifVictoire('X'));
    }
}