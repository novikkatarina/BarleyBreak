namespace TheGame
{
  public class MoveLeftCommand : ICommand
  {
    protected Game Game { get; private set; }

    public MoveLeftCommand(Game game)
    {
      this.Game = game;
    }
    public void Execute()
    {
      LogicEngine.MovePointerLeft(Game);
    }
  }
}
