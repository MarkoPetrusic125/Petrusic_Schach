using System;
using klasse;
namespace program;
class Program
{
    static void Main()
    {
        Board game = new Board();

        while (true)
        {
            Console.Clear();

            Console.WriteLine(game);

            try
            {
                Console.WriteLine("Von X:");
                int fromX = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Von Y:");
                int fromY = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Nach X:");
                int toX = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Nach Y:");
                int toY = Convert.ToInt32(Console.ReadLine());

                game.MoveFigure(fromX, fromY, toX, toY);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Fehler: " + ex.Message);
                Console.WriteLine("Enter drücken...");
                Console.ReadLine();
            }
        }
    }
}