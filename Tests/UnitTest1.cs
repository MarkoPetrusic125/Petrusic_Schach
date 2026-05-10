namespace Tests;
using Xunit;
using klasse;

public class PlayerTests
{
    [Fact]
    public void GetColor_resturns_white()
    {
        Player player = new Player("white");

        string color = player.GetColor();

        Assert.Equal("white", color);
    }
}



public class FigureTests
{
    [Fact]
    public void King_white_returns_K()
    {
        Figures king = new Figures("King", "white");

        string result = king.ToString();

        Assert.Equal("K", result);
    }
}



public class SetupBoardTests
{
    [Fact]
    public void Setup_kingIstPlaced()
    {
        Board board = new Board();

        string output = board.ToString();

        Assert.Contains("K", output);
    }

    [Fact]
    public void Setup_Rook1IstPlaced()
    {
        Board board = new Board();

        string output = board.ToString();

        Assert.Contains("R", output);
    }

    [Fact]
    public void Setup_Rook2IstPlaced()
    {
        Board board = new Board();

        string output = board.ToString();

        Assert.Contains("R", output);
    }

    [Fact]
    public void Queen_IsPlaced()
    {
        Board board = new Board();

        string output = board.ToString();

        Assert.Contains("Q", output);
    }

}



public class KingMovementTests
{
    [Fact]
    public void MoveFigure_MovesKingCorrectly()
    {
        Board board = new Board();

        board.MoveFigure("King", 4, 1);

        string output = board.ToString();

        Assert.Contains("K", output);
    }

    [Fact]
    public void MoveFigure_KingmvesOneStep()
    {
        Board board = new Board();

        board.MoveFigure("King", 5, 1);

        string result = board.ToString();

        Assert.Contains("K", result);
    }

    [Fact]
    public void KingCannotMove_more1_filed()
    {
        Board board = new Board();

        try
        {
            board.MoveFigure("King", 6, 6);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void MoveFigure_King_more_1_filed()
    {
        Board board = new Board();

        try
        {
            board.MoveFigure("King", 6, 6);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void MoveFigure_Kingdoes_not_Dissapear()
    {
        Board board = new Board();

        string before = board.ToString();

        try
        {
            board.MoveFigure("King", 4, 0);
        }
        catch { }

        string after = board.ToString();

        Assert.Equal(before, after);
    }
}



public class RookMovementTests
{
    [Fact]
    public void MoveFigure_Rook1Moves()
    {
        Board board = new Board();

        board.MoveFigure("Rook1", 0, 3);

        string result = board.ToString();

        Assert.Contains("R", result);
    }

    [Fact]
    public void MoveFigure_Rook2Moves()
    {
        Board board = new Board();

        board.MoveFigure("Rook2", 7, 3);

        string result = board.ToString();

        Assert.Contains("R", result);
    }

    [Fact]
    public void MoveFigure_Rook_1_and_2_MoveHorizontal()
    {
        Board board = new Board();

        board.MoveFigure("Rook1", 0, 2);

        string result = board.ToString();

        Assert.Contains("R", result);
    }

    [Fact]
    public void MoveFigure_RookMovesVertical()
    {
        Board board = new Board();

        board.MoveFigure("Rook1", 0, 4);

        string result = board.ToString();

        Assert.Contains("R", result);
    }

    [Fact]
    public void MoveFigure_Rook_just_horizontal_not_diagonal()
    {
        Board board = new Board();

        try
        {
            board.MoveFigure("Rook1", 1, 1);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void Rook_CannotJumpoverFigure()
    {
        Board board = new Board();

        try
        {
            board.MoveFigure("Rook1", 6, 0);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }
}


public class QueenMovementTests
{
    [Fact]
    public void Queen_Can_Move_Vertical()
    {
        Board board = new Board();

        board.MoveFigure("Queen", 3, 4);

        string output = board.ToString();

        Assert.Contains("Q", output);
    }

    [Fact]
    public void Queen_Can_Move_Horizontal()
    {
        Board board = new Board();

        board.MoveFigure("Queen", 3, 2);

        string output = board.ToString();

        Assert.Contains("Q", output);
    }

    [Fact]
    public void Queen_Can_Move_Diagonal()
    {
        Board board = new Board();

        board.MoveFigure("Queen", 6, 3);

        string output = board.ToString();

        Assert.Contains("Q", output);
    }

    [Fact]
    public void Queen_Cannot_Move_Wrong()
    {
        Board board = new Board();

        try
        {
            board.MoveFigure("Queen", 2, 2);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void Queen_Cannot_Jump_Over_Figure()
    {
        Board board = new Board();

        try
        {
            board.MoveFigure("Queen", 5, 0);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }
}


public class InvalidMoveTests
{
    [Fact]
    public void MoveFigure_OutOfboard()
    {
        Board board = new Board();

        try
        {
            board.MoveFigure("King", 8, 0);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void Not_allowed_to_take_Own_figure()
    {
        Board board = new Board();

        try
        {
            board.MoveFigure("Rook1", 4, 0);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void MoveFigure_SamePosition_not_allowed()
    {
        Board board = new Board();

        try
        {
            board.MoveFigure("King", 4, 0);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void CannotthrowOwnFigure()
    {
        Board board = new Board();

        try
        {
            board.MoveFigure("Rook1", 4, 0);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }
}



public class TurnTests
{
    [Fact]
    public void Playerswitches_afterMove()
    {
        Board board = new Board();

        string before = board.GetCurrentPlayerColor();

        board.MoveFigure("King", 4, 1);

        string after = board.GetCurrentPlayerColor();

        Assert.NotEqual(before, after);
    }
}



public class CheckTests
{
    [Fact]
    public void BlackKing_IsInCheck()
    {
        Board board = new Board();

        board.MoveFigure("Rook1", 0, 7);

        board.MoveFigure("King", 4, 6);

        board.MoveFigure("Rook1", 0, 6);

        Assert.True(board.IsKingInCheck("black"));
    }

    [Fact]
    public void WhiteKing_IsNotInCheck_AtStart()
    {
        Board board = new Board();

        Assert.False(board.IsKingInCheck("white"));
    }

    [Fact]
    public void BlackKing_IsNotInCheck_AtStart()
    {
        Board board = new Board();

        Assert.False(board.IsKingInCheck("black"));
    }

    [Fact]
    public void Cannot_Ignore_Check()
    {
        Board board = new Board();

        board.MoveFigure("Rook1", 0, 7);

        board.MoveFigure("King", 4, 6);

        board.MoveFigure("Rook1", 0, 6);

        try
        {
            board.MoveFigure("Rook2", 7, 5);

            Assert.True(false);
        }
        catch (ArgumentException)
        {
            Assert.True(true);
        }
    }

    [Fact]
    public void King_Can_Move_Out_Of_Check()
    {
        Board board = new Board();

        board.MoveFigure("Rook1", 0, 7);

        board.MoveFigure("King", 4, 6);

        board.MoveFigure("Rook1", 0, 6);

        board.MoveFigure("King", 4, 5);

        Assert.False(board.IsKingInCheck("black"));
    }

    [Fact]
    public void Queen_Can_Give_Check()
    {
        Board board = new Board();

        board.MoveFigure("Queen", 3, 6);

        Assert.True(board.IsKingInCheck("black"));
    }
}