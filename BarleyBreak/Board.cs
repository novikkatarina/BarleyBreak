public class Board
{
  public string[,] BoardArray { get; private set; }
  protected int Width { get; private set; }
  protected int Height { get; private set; }
  protected int[] Pointer {  get; private set; }
  protected bool IsPlaying { get; private set; }

  public Board(int size)
  {
    this.BoardArray = FillArray(size);
    this.Width = size;
    this.Height = size;
    this.Pointer = new int[4] { this.Width - 1, this.Height - 1, 0, 0 };
    Bindings.Initialize(this);
    this.IsPlaying = true;
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

  public bool CheckValidCombination(string[,] array)
  {
    int game_possible = 0;

    for (int row = 0; row < 3; row++)
    {
      for (int column = 0; column < 2; column++)
      {
        if (Convert.ToInt32(array[row, column]) > Convert.ToInt32(array[row, column + 1]))
        {
          game_possible++;
        }
      }
    }

    return game_possible % 2 == 0;
  }

  // Считываение кнопки и запуск функции
  public void Input()
  {
    do
    {
      ConsoleKeyInfo keyPressed = Console.ReadKey();
      if (Bindings.Commands.ContainsKey(keyPressed.Key.ToString()))
        Bindings.Commands[keyPressed.Key.ToString()].Execute();
    }
    while (this.IsPlaying);
  }

  // Обновление поля после изменений
  public void Update()
  {
    string temp = this.BoardArray[this.Pointer[0], this.Pointer[1]];
    this.BoardArray[this.Pointer[0], this.Pointer[1]] = "0";
    this.BoardArray[this.Pointer[2], this.Pointer[3]] = temp;

    if (this.Pointer[0] == this.Width - 1 && this.Pointer[1] == this.Height - 1)
    {
      this.IsWin(this.BoardArray);
    }

    if(IsPlaying)
      this.Print(this.BoardArray);
    }

  // Передвижение указателя вверх
  public void MovePointerUp()
  {
    int temp = this.Pointer[0];
    if (temp-- > 0)
    {
      this.Pointer[2] = this.Pointer[0];
      this.Pointer[3] = this.Pointer[1];

      this.Pointer[0]--;
      this.Update();
    }

  }

  // Передвижение указателя вниз
  public void MovePointerDown()
  {
    int temp = this.Pointer[0];
    if (temp++ < this.Height - 1)
    {
      this.Pointer[2] = this.Pointer[0];
      this.Pointer[3] = this.Pointer[1];

      this.Pointer[0]++;
      this.Update();
    }
  }

  // Передвижение указателя влево
  public void MovePointerLeft()
  {
    int temp = this.Pointer[1];
    if (temp-- > 0)
    {
      this.Pointer[2] = this.Pointer[0];
      this.Pointer[3] = this.Pointer[1];

      this.Pointer[1]--;
      this.Update();
    }
  }

  // Передвижение указателя вправо
  public void MovePointerRight()
  {
    int temp = this.Pointer[1];
    if (temp++ < this.Width - 1)
    {
      this.Pointer[2] = this.Pointer[0];
      this.Pointer[3] = this.Pointer[1];

      this.Pointer[1]++;
      this.Update();
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

// На случай если нужен массив из чисел от 1 до 9 подряд
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
