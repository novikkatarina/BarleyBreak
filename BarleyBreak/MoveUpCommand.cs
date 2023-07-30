namespace BarleyBreak
{
  public class MoveUpCommand : ICommand
  {
    protected Game Game { get; private set; }

    public MoveUpCommand(Game game)
    {
      Game = game;
    }
    public void Execute()
    {
      LogicEngine.MovePointerUp(Game);
    }
  }
}
