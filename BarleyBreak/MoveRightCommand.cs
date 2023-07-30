namespace BarleyBreak
{
  public class MoveRightCommand : ICommand
  {
    protected Game Game { get; private set; }

    public MoveRightCommand(Game game)
    {
      Game = game;
    }
    public void Execute()
    {
      LogicEngine.MovePointerRight(Game);
    }
  }
}
