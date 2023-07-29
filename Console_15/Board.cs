namespace TheGame
{
  public class Board
  {
    // Указатель: Pointer[0], Pointer[1]; и прошлая позиция указателя: Pointer[2], Pointer[3]
    public int[] Pointer { get; private set; }

    // Доска и её параметры
    public int[,]? Array { get; private set; }

    // BoardParams[0] - Width; BoardParams[1] - Height
    public int[] Params { get; private set; }

    // Ограничитель высоты и ширины поля
    public int Limiter { get; private set; }

    // Заполнение матрицы Пятнашек числами
    public void Fill()
    {
      this.Array = new int[this.Params[1], this.Params[0]];
      Random rnd = new Random();
      int maxValue = this.Params[0] * this.Params[1];
      IEnumerable<int> numbers = Enumerable.Range(1, maxValue - 1);

      // Перемешивание коллекции в случайном порядке
      numbers = numbers.OrderBy(n => rnd.Next());
      IEnumerator<int> currentNumber = numbers.GetEnumerator();

      // Заполнение двумерного массива числами из перемешанной одномерной коллекции
      for (int i = 0; i < this.Params[1]; i++)
      {
        for (int j = 0; j < this.Params[0]; j++)
        {
          this.Array[i, j] = currentNumber.Current;
          currentNumber.MoveNext();
        }
      }
      // Перемена первого и последнего элементов для пустой клетки в конце
      int temp = this.Array[this.Params[1] - 1, this.Params[0] - 1];
      this.Array[this.Params[1] - 1, this.Params[0] - 1] = 0;
      this.Array[0, 0] = temp;
      this.Pointer = new int[4] { this.Params[1] - 1, this.Params[0] - 1, this.Params[1] - 1, this.Params[0] - 1 };
    }

    // Отрисовка матрицы Пятнашек
    public void Print()
    {
      Console.Clear();
      Console.WriteLine("Пятнашки!\nСоставьте все цифры по порядку слева\nнаправо (с переносом на новую строку):\n");
      string tableRow = "";
      for (int i = 0; i < this.Params[1]; i++)
      {
        for (int j = 0; j < this.Params[0]; j++)
        {
          if (Array[i, j] == 0)
          {
            // Пустая клетка на месте нуля
            tableRow += "[   ]\t";
            continue;
          }
          tableRow += "[ " + this.Array[i, j] + " ]\t";
        }
        Console.WriteLine(tableRow + "\n");
        tableRow = "";
      }
      Console.WriteLine("\nСправка:\n- Перемещение ячеек - СТРЕЛКИ\n- Перезапуск - \"R\"\n- Выход - \"E\"");
    }

    // Сброс значений доски
    public void Reset()
    {
      this.Pointer = new int[4] { 0, 0, 0, 0, };
      this.Params = new int[2] { 0, 0 };
    }

    public Board()
    {
      this.Pointer = new int[4] { 0, 0, 0, 0, };
      this.Params = new int[2] { 0, 0 };
      this.Limiter = 4;
    }
  }
}
