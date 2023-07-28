namespace Console_15
{
  internal class ExitCommand : ICommand
  {
    protected Game Board { get; private set; }
    public ExitCommand(Game board)
    {
      this.Board = board;
    }
    public void Execute()
    {
      Board.Exit();
    }
  }
}
