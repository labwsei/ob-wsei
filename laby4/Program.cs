using System;
using System.Diagnostics.Tracing;
using System.Drawing;

class App
{
  public static void Main(string[] args)
  {
    (int, int) point1 = (2, 4);
    (int, int) screen = (20, 40);
    Direction4 dir = Direction4.UP;
    var point2 = Exercise1.NextPoint(dir, point1, screen);
    Console.WriteLine(point2);
    int[,] screen2 =
  {
        {1, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };
    Console.WriteLine(Exercise2.DirectionTo(screen2, (1, 1), 1));

    Car[] _cars = new Car[]
  {
    new Car(),
    new Car(Model: "Fiat", true),
    new Car(),
    new Car(Power: 100),
    new Car(Model: "Fiat", true),
    new Car(Power: 125),
    new Car()
  };
    Console.WriteLine(Exercise3.CarCounter(_cars));

    Student[] students = {
 new Student("Kowal","Adam", 'A'),
 new Student("Nowak","Ewa", 'A')
};
    Exercise4.AssignStudentId(students);
    foreach (var item in students)
    {
      Console.WriteLine(item);
    }
  }
}

enum Direction8
{
  UP,
  DOWN,
  LEFT,
  RIGHT,
  UP_LEFT,
  DOWN_LEFT,
  UP_RIGHT,
  DOWN_RIGHT
}

enum Direction4
{
  UP,
  DOWN,
  LEFT,
  RIGHT
}

//Cwiczenie 1
//Zdefiniuj metodę NextPoint, która powinna zwracać krotkę ze współrzędnymi piksela przesuniętego jednostkowo w danym kierunku względem piksela point.
//Krotka screenSize zawiera rozmiary ekranu (width, height)
//Przyjmij, że początek układu współrzednych (0,0) jest w lewym górnym rogu ekranu, a prawy dolny ma współrzęne (witdh, height) 
//Pzzykład
//dla danych wejściowych 
//(int, int) point1 = (2, 4);
//Direction4 dir = Direction4.UP;
//var point2 = NextPoint(dir, point1);
//w point2 powinny być wartości (2, 3);
//Jeśli nowe położenie jest poza ekranem to metoda powinna zwrócić krotkę z point
class Exercise1
{
  public static (int, int) NextPoint(Direction4 direction, (int, int) point, (int, int) screenSize)
  {
    int x = point.Item1;
    int y = point.Item2;
    int m_x = screenSize.Item1;
    int m_y = screenSize.Item2;
    switch (direction)
    {
      case Direction4.UP:
        return (x, y - 1 < 0 ? y : y - 1);

      case Direction4.DOWN:
        return (x, y + 1 > m_y ? y : y + 1);

      case Direction4.LEFT:
        return (x - 1 < 0 ? x : x - 1, y);


      case Direction4.RIGHT:
        return (x + 1 > m_x ? x : x + 1, y);

      default:
        return (x, y);
    }

  }
}
//Cwiczenie 2
//Zdefiniuj metodę DirectionTo, która zwraca kierunek do piksela o wartości value z punktu point. W tablicy screen są wartości
//pikseli. Początek układu współrzędnych (0,0) to lewy górny róg, więc punkt o współrzęnych (1,1) jest powyżej punktu (1,2) 
//Przykład
// Dla danych weejsciowych
// static int[,] screen =
// {
//    {1, 0, 0},
//    {0, 0, 0},
//    {0, 0, 0}
// };
// (int, int) point = (1, 1);
// po wywołaniu - Direction8 direction = DirectionTo(screen, point, 1);
// w direction powinna znaleźć się stała UP_LEFT
class Exercise2
{
  static int[,] screen =
  {
        {1, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };

  private static (int, int) point = (1, 1);

  private Direction8 direction = DirectionTo(screen, point, 1);

  public static Direction8 DirectionTo(int[,] screen, (int, int) point, int value)
  {

    int px = point.Item1;
    int py = point.Item2;
    for (var i = 0; i < screen.GetLength(0); i++)
    {
      for (var j = 0; j < screen.GetLength(1); j++)
      {
        if (screen[i, j] == value)
        {
          if (j < px && i == py)
          {
            return Direction8.LEFT;
          }
          if (j > px && i == py)
          {
            return Direction8.RIGHT;
          }
          if (j == px && i > py)
          {
            return Direction8.UP;
          }
          if (j == px && i == py)
          {
            return Direction8.DOWN;
          }
          if (j < px && i > py)
          {
            return Direction8.DOWN_LEFT;
          }
          if (j > px && i > py)
          {
            return Direction8.DOWN_RIGHT;
          }

          if (j < px && i < py)
          {
            return Direction8.UP_LEFT;
          }
          if (j > px && i < py)
          {
            return Direction8.UP_RIGHT;
          }
          break;
        }
      }
    }
    return Direction8.UP;

  }
}

//Cwiczenie 3
//Zdefiniuj metodę obliczającą liczbę najczęściej występujących aut w tablicy cars
//Przykład
//dla danych wejściowych
// Car[] _cars = new Car[]
// {
//     new Car(),
//     new Car(Model: "Fiat", true),
//     new Car(),
//     new Car(Power: 100),
//     new Car(Model: "Fiat", true),
//     new Car(Power: 125),
//     new Car()
// };
//wywołanie CarCounter(Car[] cars) powinno zwrócić 3
record Car(string Model = "Audi", bool HasPlateNumber = false, int Power = 100);

class Exercise3
{
  public static int CarCounter(Car[] cars)
  {
    foreach (var car in cars)
    {
      Console.WriteLine(car);
    }
    return 0;
  }
}

record Student(string LastName, string FirstName, char Group, string StudentId = "");
//Cwiczenie 4
//Zdefiniuj metodę AssignStudentId, która każdemu studentowi nadaje pole StudentId wg wzoru znak_grupy-trzycyfrowy-numer.
//Przykład
//dla danych wejściowych
//Student[] students = {
//  new Student("Kowal","Adam", 'A'),
//  new Student("Nowak","Ewa", 'A')
//};
//po wywołaniu metody AssignStudentId(students);
//w tablicy students otrzymamy:
// Kowal Adam 'A' - 'A001'
// Nowal Ewa 'A'  - 'A002'
//Należy przyjąc, że są tylko trzy możliwe grupy: A, B i C
class Exercise4
{
  public static void AssignStudentId(Student[] students)
  {
    int[] groupCounter = new int[] { 0, 0, 0 };
    int counter = 0;
    foreach (var student in students)
    {
      string nmbr = student.Group.ToString();
      switch (student.Group)
      {
        case 'A':
          groupCounter[0]++;
          nmbr += string.Format("{0:000}", groupCounter[0]);

          break;
        case 'B':
          groupCounter[1]++;
          nmbr += string.Format("{0:000}", groupCounter[1]);

          break;
        case 'C':
          groupCounter[2]++;
          nmbr += string.Format("{0:000}", groupCounter[2]);

          break;
      }
      students[counter] = new Student(student.LastName, student.FirstName, student.Group, nmbr);

      Console.WriteLine($"{student.LastName} {student.FirstName} '{student.Group}' - '{nmbr}'");
      counter++;
    }
  }
}