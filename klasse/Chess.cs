namespace klasse;

public class Chess{

    private ChessFigure[,] board = new ChessFigure[8, 8];


     public override string ToString()
    {

        string result = "";

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {

                if( (x+y) %2 == 0){
                    result += "   ";
                }
                else{
                    result += " # ";
                }


                if (board[x, y] == null)
                {
                    result += "";
                }
                else
                {
                    result += board[x, y].ToString();
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
}