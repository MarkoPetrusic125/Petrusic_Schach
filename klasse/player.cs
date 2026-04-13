namespace klasse;

public class Player
{
    private string _color;

    public Player(string color)
    {
        _color = color;
    }

    public string GetColor(){
        return _color;
    }
}