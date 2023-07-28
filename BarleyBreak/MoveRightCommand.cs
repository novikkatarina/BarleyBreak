public class MoveRightCommand : ICommand
{
  protected Board Board { get; private set; }

  public MoveRightCommand(Board board)
  {
    this.Board = board;
  }
  public void Execute()
  {
    Board.MovePointerRight();
  }
}
