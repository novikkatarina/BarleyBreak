namespace BarleyBreak
{
  public class MoveLeftCommand : ICommand
  {
    protected Game Game { get; private set; }

    public MoveLeftCommand(Game game)
    {
      Game = game;
    }
    public void Execute()
    {
      LogicEngine.MovePointerLeft(Game);
    }
  }
}
