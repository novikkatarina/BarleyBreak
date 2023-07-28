namespace Console_15
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Game game = new Game();
      Bindings.Initialize(game);
      game.Start();
    }
  }
}