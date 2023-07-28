namespace Console_15
{
  public class MoveDownCommand : ICommand
  {
    protected Game Board { get; private set; }

    public MoveDownCommand(Game board)
    {
      this.Board = board;
    }
    public void Execute()
    {
      Board.MovePointerDown();
    }
  }
}
