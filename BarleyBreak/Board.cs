public class Board
{
  public string[,] BoardArray { get; private set; }

  public Board(int size)
  {
    this.BoardArray = FillArray(size);
  }

  public string[,] FillArray(int size)
  {
    string[,] array = new String[size, size];
    Random random = new Random();
    IEnumerable<int> numbers = Enumerable.Range(1, 8);
    numbers = numbers.OrderBy(n => random.Next());


    int i = 0;
    foreach (var number in numbers)
    {
      int row = i / 3; // integer division to get the row index
      int column = i % 3; // modulus to get the column index

      array[row, column] = number.ToString();
      i++;
    }

    array[size - 1, size - 1] = " ";
    return array;
  }

  public void Print(string[,] array)
  {
    for (int i = 0; i < 3; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        Console.Write($"[{array[i, j]}]\t");
      }

      Console.WriteLine();
    }
  }

  public void IsWin(string[,] array)
  {
    int number = 1;
    for (int i = 0; i < 3; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        if (array[i, j] != number.ToString()) return;
        number++;
      }
    }

    Console.WriteLine("You won!");
  }

// На случай усли нужен массив из чисел от 1 до 9 подряд
  public string[,] FillArray2(int size)
  {
    string[,] array = new String[size, size];
    int number = 1;
    for (int i = 0; i < 3; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        array[i, j] = number.ToString();
        number++;
      }
    }

    array[size - 1, size - 1] = "  ";

    return array;
  }
}
