namespace Console_15
{
  public class MoveUpCommand : ICommand
  {
    protected Game board { get; private set; }

    public MoveUpCommand(Game board)
    {
      this.board = board;
    }
    public void Execute()
    {
      board.MovePointerUp();
    }
  }
}
