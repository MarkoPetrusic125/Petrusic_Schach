namespace Tests;
using Xunit;
using klasse;


public class BoardTests
{
    [Fact]
    public void Setup_kingIstPlaced()
    {
        Board board = new Board();

        string output = board.ToString();

        Assert.Contains("K", output);
    }

    [Fact]
    public void GetColor_resturns_white()
    {
        Player player = new Player("white");

        string color = player.GetColor();

        Assert.Equal("white", color);
    }

    [Fact]
    public void King_white_returns_K()
    {
        Figures king = new Figures("King", "white");

        string result = king.ToString();

        Assert.Equal("K", result);
    }
}


