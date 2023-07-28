public class MoveUpCommand : ICommand
{
  protected Board Board { get; private set; }

  public MoveUpCommand(Board board)
  {
    this.Board = board;
  }
  public void Execute()
  {
    Board.MovePointerUp();
  }
}
