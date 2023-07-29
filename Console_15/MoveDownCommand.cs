namespace TheGame
{
  public class MoveDownCommand : ICommand
  {
    protected Game Game { get; private set; }

    public MoveDownCommand(Game game)
    {
      Game = game;
    }
    public void Execute()
    {
      LogicEngine.MovePointerDown(Game);
    }
  }
}
