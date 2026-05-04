using System;

namespace klasse;

public class Board
{
    private Figures[,] board = new Figures[8, 8];

    private Player white = new Player("white");
    private Player black = new Player("black");

    private Player currentPlayer;


    public string GetCurrentPlayerColor()
    {
        return currentPlayer.GetColor();
    }


    public Board()
    {

        white = new Player("white");
        black = new Player("black");

        currentPlayer = white;

        SetupBoard();
    }



    public void SetupBoard()
    {
        board[4, 0] = new Figures("King", white.GetColor());
        board[0, 0] = new Figures("Rook1", white.GetColor());
        board[7, 0] = new Figures("Rook2", white.GetColor());

        board[4, 7] = new Figures("King", black.GetColor());
        board[0, 7] = new Figures("Rook1", black.GetColor());
        board[7, 7] = new Figures("Rook2", black.GetColor());

    }

    public void SetFigure(int x, int y, Figures figure)
    {
        board[x, y] = figure;
    }


    public override string ToString()
    {
        string result = "";

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (board[x, y] == null)
                {
                    if ((x + y) % 2 == 0)
                    {
                        result += "   ";
                    }
                    else
                    {
                        result += " # ";
                    }
                }
                else

                {
                    string symbol = board[x, y].ToString();

                    if (symbol.Length == 1)

                        symbol = " " + symbol + " ";

                    else if (symbol.Length == 2)

                        symbol = " " + symbol;

                    result += symbol;
                }

                if (x < 7)
                {
                    result += "|";
                }
            }

            if (y < 7)
            {
                result += "\n---+---+---+---+---+---+---+---\n";
            }
        }
        return result;
    }


    public void MoveFigure(string? name, int toX, int toY)
    {
        int fromX = 0;
        int fromY = 0;
        bool found = false;

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (board[x, y] != null &&
                    board[x, y].GetName() == name)
                {

                    if (board[x, y].GetColor() != currentPlayer.GetColor())
                        continue;

                    fromX = x;
                    fromY = y;
                    found = true;
                }
            }
        }

        if (!found)
            throw new ArgumentException("Figur nicht gefunden");



        if (board[fromX, fromY].GetColor() != currentPlayer.GetColor())
        {
            throw new ArgumentException("Du bist nicht dran");
        }


        if (toX < 0 || toX > 7 || toY < 0 || toY > 7)
        {
            throw new ArgumentException("Ziel ist außerhalb vom Brett");
        }

        if (board[fromX, fromY] == null)
        {
            throw new ArgumentException("Figur existiert nicht");
        }

        if (fromX == toX && fromY == toY)
        {
            throw new ArgumentException("Figur bleibt stehen");
        }


        if (name == "King")
        {
            int dx = Math.Abs(toX - fromX);
            int dy = Math.Abs(toY - fromY);

            if (dx > 1 || dy > 1)
                throw new ArgumentException("King darf nur 1 Feld bewegen");
        }

        if (name == "Rook1" || name == "Rook2")
        {
            if (fromX != toX && fromY != toY)
                throw new ArgumentException("Rook darf nur gerade ziehen");

            int dx = Math.Sign(toX - fromX);
            int dy = Math.Sign(toY - fromY);

            int x = fromX + dx;
            int y = fromY + dy;

            while (x != toX || y != toY)
            {
                if (board[x, y] != null)
                {
                    throw new ArgumentException("Rook darf nicht über Figuren springen");
                }

                x += dx;
                y += dy;
            }
        }

        if (board[toX, toY] != null)
        {
            if (board[toX, toY].GetColor() == board[fromX, fromY].GetColor())
            {
                throw new ArgumentException("Eigene Figur darf nicht geschlagen werden");
            }
        }

        

        board[toX, toY] = board[fromX, fromY];
        board[fromX, fromY] = null;




        if (currentPlayer == white)
            currentPlayer = black;
        else
            currentPlayer = white;

    }
}